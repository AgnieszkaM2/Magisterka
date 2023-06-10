using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiagnosticApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymptomsController : ControllerBase
    {
        private readonly DiagnosticAppContext _context;

        public SymptomsController(DiagnosticAppContext context)
        {
            _context = context;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Symptom>>> GetSymptoms()
        {
            return Ok(await _context.Symptoms.ToListAsync());
        }

        [HttpGet("GetSpecific")]
        public async Task<ActionResult<List<Disease>>> GetSpecificSymptom(int id)
        {
            return Ok(await _context.Symptoms
                .Where(s => s.IdSymptom == id)
                .ToListAsync());
        }
    }
}
