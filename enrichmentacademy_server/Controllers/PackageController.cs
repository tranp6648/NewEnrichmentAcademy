using EnrichmentAcademy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnrichmentAcademy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly PackageService packageService;
        public PackageController(PackageService packageService)
        {
            this.packageService = packageService;
        }
        [HttpPost("CreatePackage")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> AddPackage([FromBody]Data.CreatePackage package)
        {
            try
            {
                return Ok(await packageService.CreatePackage(package));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("ShowSubject")]
        public async Task<IActionResult> ShowSubject()
        {
            try
            {
                return Ok(await packageService.ShowSubject());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
