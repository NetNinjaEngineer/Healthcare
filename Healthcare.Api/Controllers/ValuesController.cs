using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Healthcare.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ValuesController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpPost, DisableRequestSizeLimit]
    public IActionResult Upload([FromForm] FormModel model)
    {
        try
        {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine(_webHostEnvironment.WebRootPath, "Files");

            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(folderName, fileName);

                using var fileStream = new FileStream(fullPath, FileMode.Create);
                file?.CopyTo(fileStream);

                return Ok("Uploaded");
            }
            else
                return BadRequest();

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

public class FormModel
{
    public IFormFile File { get; set; }
}
