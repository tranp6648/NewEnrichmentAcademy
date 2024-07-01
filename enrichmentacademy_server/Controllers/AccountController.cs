using EnrichmentAcademy.Data;
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
        [HttpPut("CheckOTP/{email}/{otp}")]
        [Produces("application/json")]
        public async Task<IActionResult>CheckOTP(string email,string otp)
        {
            try
            {
                return Ok(await AccoutService.CheckOTP(email, otp));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("ResetPassword/{email}/{password}")]
        [Produces("application/json")]
        public async Task<IActionResult> ResetPassword(string email,string password)
        {
            try
            {
                return Ok(await AccoutService.ResetPassword(email, password));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("ForgotPassword/{email}")]
        [Produces("application/json")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                return Ok(await AccoutService.ForgotPassword(email));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("ApproveActive/{id}/{email}")]
        [Produces("application/json")]
        public async Task<IActionResult> ApproveActive(int id,string email)
        {
            try
            {
                return Ok(await AccoutService.ApproveActive(id,email));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("LoginAccount/{Email}/{Password}")]
        public async Task<IActionResult>LoginAccount(string Email, string Password)
        {
            try
            {
                return Ok(await AccoutService.Login(Email, Password,Response));
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
