using CrudWebAssemblyR51.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudWebAssemblyR51.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment env;

        public UploadController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        [HttpPost]
        public async Task Post([FromBody] ImageFile[] files)
        {
            foreach (var file in files)
            {
                string f = @"C:\Users\diit\source\repos\CrudWebAssemblyR51\CrudWebAssemblyR51\Client\wwwroot\Uploads\";
                var buf = Convert.FromBase64String(file.base64data);
                await System.IO.File.WriteAllBytesAsync(f + file.fileName, buf);
            }
        }

    }
}
