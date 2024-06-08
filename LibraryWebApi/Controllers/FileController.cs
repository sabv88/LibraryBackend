using LibraryWebApi.Models.Files;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace LibraryWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FileController : BaseController
    {
        [HttpGet]
        public IActionResult GetImage(string pathToFile)
        {
            var image = System.IO.File.OpenRead(pathToFile);
            var a = File(image, "image/" + Path.GetExtension(pathToFile));
            return File(image, "image/"+ Path.GetExtension(pathToFile));
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddFile([FromForm] ImageDto file)
        {
            var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";
            Directory.CreateDirectory(uploadPath);
            string fullPath = $"{uploadPath}/{file.FormFile.FileName}";

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.FormFile.CopyToAsync(fileStream);
            }
            string basePath = "https://localhost:7014";

            return Ok(basePath + "/api/file/" + file.FormFile.FileName);
        }
    }
}
