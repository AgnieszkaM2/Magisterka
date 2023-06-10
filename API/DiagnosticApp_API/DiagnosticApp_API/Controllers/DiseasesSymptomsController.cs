using DiagnosticApp_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiagnosticApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesSymptomsController : ControllerBase
    {
        private readonly DiagnosticAppContext _context;

        public DiseasesSymptomsController(DiagnosticAppContext context)
        {
            _context = context;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<DiseasesSymptom>>> GetAllDiseasesSymptoms()
        {
            return Ok(await _context.DiseasesSymptoms.Select(s => new{ s.IdDisease, s.IdSymptom }).ToListAsync()) ;
        }

       [HttpGet("GetComplete")]
        public async Task<ActionResult<List<DiseasesSymptom>>> GetCompleteDiseasesSymptoms()
        {

            return Ok(await _context.DiseasesSymptoms
                .Include(s => s.IdDiseaseNavigation).Select(s=> new { s.IdDisease, s.IdSymptom, s.IdSymptomNavigation.Weight })
                .ToListAsync());
        }
    }
}
