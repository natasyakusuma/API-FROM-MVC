using Microsoft.AspNetCore.Mvc;

namespace APISolution.Controllers
{
    public class UploadFileController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is required");
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok("Upload file success");
        }
    }
}
