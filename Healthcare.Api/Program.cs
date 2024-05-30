using Healthcare.Application;
using Healthcare.Application.Middleware;
using Healthcare.Infrastructure;
using Healthcare.Infrastructure.Persistence;
using Healthcare.Infrastructure.Persistence.DataSeed;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var databaseContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    SeedDatabase.Seed(databaseContext);
}

app.UseMiddleware<GlobalExceptionHandingMiddleware>();

app.UseMiddleware<LoggingMiddleware>();

app.UseCors(c => c.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
