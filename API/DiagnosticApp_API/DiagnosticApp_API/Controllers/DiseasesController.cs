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

        [HttpGet("GetSpecific/{id}")]
        public async Task<ActionResult<List<Disease>>> GetSpecificDiseases(int id)
        {
            return Ok(await _context.Diseases
                .Where(s => s.IdDisease==id)
                .ToListAsync());
        }

        [HttpPost("IdList")]
        public async Task<ActionResult<List<Disease>>> IdList(int[] idlist)
        {
            var receivedList = idlist;
            int []temp = { 3, 9, 1, 4, 5 };
            
            return Ok(temp);
        }

        [HttpPost("GetAllSpecific")]
        public async Task<ActionResult<List<Disease>>> GetAllSpecificDiseases(int []id)
        {
            var res= await _context.Diseases
                .Where(s => id.Contains(s.IdDisease))
                .ToListAsync();

                
            return Ok(new {results=res, order=id});
        }


    }
}
