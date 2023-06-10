using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DiagnosticApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly DiagnosticAppContext _context;

        public DiseasesController(DiagnosticAppContext context)
        {
            _context = context;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Disease>>> GetDiseases() 
        {
            return Ok( await _context.Diseases.ToListAsync() );
        }

        [HttpGet("GetSpecific")]
        public async Task<ActionResult<List<Disease>>> GetSpecificDiseases(int id)
        {
            return Ok(await _context.Diseases
                .Where(s => s.IdDisease==id)
                .ToListAsync());
        }


    }
}
