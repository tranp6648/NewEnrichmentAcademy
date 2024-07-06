using EnrichmentAcademy.Data;
using EnrichmentAcademy.Models;
using EnrichmentAcademy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnrichmentAcademy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;
        private readonly FacultyServiece facultyServiece;
        public FacultyController(FacultyServiece facultyServiece,DatabaseContext databaseContext)
        {
            this.facultyServiece = facultyServiece;
            this.databaseContext = databaseContext;
        }
        [HttpGet("ShowFaculty")]
        public async Task<IActionResult> ShowFaculty()
        {
            try
            {
                return Ok(await facultyServiece.ShowFaculty());
            }
            catch
            {
                return BadRequest();
            }
        }
       
        [HttpDelete("DeleteFaculty/{id}")]
        public async Task<IActionResult> DeleteFaculty(int id)
        {
            try
            {
                return Ok(await facultyServiece.DeleteFaculty(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateFaculty/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateFaculty(int id,CreateFaculty createFaculty)
        {
            try
            {
                if(databaseContext.Faculties.Any(x=>x.Id!= id && x.Name == createFaculty.Name))
                {
                    return BadRequest(new { message = "Name is already Exists" });
                }
                return Ok(await facultyServiece.UpdateFaculty(id, createFaculty));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CreateFaculty")]
        public async Task<IActionResult> CreateFaculty(CreateFaculty createFaculty)
        {
            try
            {
                if(databaseContext.Faculties.Any(d=>d.Name==createFaculty.Name)) {
                    return BadRequest(new { message = "Name is already Exists" });
                }
                return Ok(await facultyServiece.CreateFaculty(createFaculty));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
