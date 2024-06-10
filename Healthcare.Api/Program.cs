using Asp.Versioning;
using Healthcare.Application;
using Healthcare.Application.Middleware;
using Healthcare.Infrastructure;
using Healthcare.Infrastructure.Persistence;
using Healthcare.Infrastructure.Persistence.SeedWork;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
    options.OutputFormatters.RemoveType<StringOutputFormatter>();
}).AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.ReportApiVersions = true;
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-version"),
        new MediaTypeApiVersionReader("ver"));
})
    .AddApiExplorer(opt =>
    {
        opt.GroupNameFormat = "'v'VVV"; //  format the version as “‘v’major[.minor][-status]”.
        opt.SubstituteApiVersionInUrl = true; // necessary when versioning by the URI segment
    });

builder.Services.AddCors();

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 250 * 1024 * 1024;
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 250 * 1024 * 1024;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var databaseContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await SeedDatabase.Seed(databaseContext);
}

app.UseStaticFiles();

app.UseMiddleware<GlobalExceptionHandingMiddleware>();

app.UseMiddleware<LoggingMiddleware>();

app.UseCors(c => c.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
