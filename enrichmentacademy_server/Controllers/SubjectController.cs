using EnrichmentAcademy.Data;
using EnrichmentAcademy.Models;
using EnrichmentAcademy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnrichmentAcademy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectService subjectService;
        private readonly DatabaseContext databaseContext;
        public SubjectController(SubjectService subjectService,DatabaseContext databaseContext)
        {
            this.subjectService = subjectService;
            this.databaseContext = databaseContext;
        }
        [HttpGet("ShowFaculty")]
        public async Task<IActionResult> ShowFaculty()
        {
            try
            {
                return Ok(await subjectService.ShowFaculty());
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
                return Ok( await subjectService.ShowSubject());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateSubject/{id}")]
        public async Task<IActionResult>UpdateSubject(int id, [FromBody]UpdateSubject subject)
        {
            try
            {
                if (databaseContext.SubjectDbs.Any(d => d.Name == subject.Name && d.Id!=id))
                {
                    return BadRequest(new { message = "Name is already Exists" });
                }
                return Ok(await subjectService.UpdateSubject(id, subject));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteSubject/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult>DeleteSubject(int id)
        {
            try
            {
                return Ok(await subjectService.DeleteSubject(id));
            }
            catch
            {
                return BadRequest();    
            }
        }
        [HttpPost("AddSubject")]
        [Produces("application/json")]
        public async Task<IActionResult> AddSubject([FromForm] AddSubject subject)
        {
            try
            {
                if (databaseContext.SubjectDbs.Any(d => d.Name == subject.Name))
                {
                    return BadRequest(new { message = "Name is already Exists" });
                }
                return Ok(await subjectService.CreateSubject(subject));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
