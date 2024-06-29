using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnrichmentAcademy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private Services.AccoutService AccoutService;
        public AccountController(Services.AccoutService AccoutService)
        {
            this.AccoutService = AccoutService;
        }
        [HttpGet("ShowAccountTeacher")]
        public async Task<IActionResult> ShowAccountTeacher()
        {
            try
            {
                return Ok(await AccoutService.ShowAccountTeacher());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("AddAccountTeacher")]
        public async Task<IActionResult>AddAccountTeacher(AddAccountTeacher addAccountTeacher)
        {
            try
            {
                return Ok(new
                {
                    result = AccoutService.AddAccountTeacher(addAccountTeacher),
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
