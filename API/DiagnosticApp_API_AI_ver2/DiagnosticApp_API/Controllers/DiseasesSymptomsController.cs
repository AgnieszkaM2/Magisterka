using DiagnosticApp_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using DiagnosticApp_API.System1;
using System.Net;
using System.IO;
using DiagnosticApp_API.System2;

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


       /* [HttpPost("Diagnose")]
        public async Task<ActionResult<List<Disease>>> IdList(int[] idlist)
        {
            var receivedList = idlist;
            var edges= await _context.DiseasesSymptoms
                .Include(s => s.IdDiseaseNavigation).Select(s => new { s.IdSymptom, s.IdDisease,  s.IdSymptomNavigation.Weight })
                .ToListAsync();
            var baseDisease= await _context.Diseases.Select(s => new { s.IdDisease, s.SumWeight, s.SymptomsCount }).ToListAsync() ;

            int accuracyLevel = 1;

            List<DiseaseVertex> diseases = new List<DiseaseVertex>() ;
            foreach (var d in baseDisease) {
                diseases.Add(new DiseaseVertex { Id=d.IdDisease, SumWeight=d.SumWeight, SumCount=d.SymptomsCount }) ;
            }
            Graph graph = new Graph() ;
            foreach (var d in edges)
            {
                graph.AddEdge(d.IdSymptom - 1, d.IdDisease - 1, d.Weight);
            }

            var result= graph.Diagnose(diseases,receivedList,accuracyLevel) ;

            return Ok(result.OrderByDescending(x => x.result));
        }*/

        [HttpPost("Diagnose")]
        public async Task<ActionResult<List<Disease>>> IdList(int[] idlist)
        {
            var receivedList = idlist;

            int accuracyLevel = 1;

            var result = AIDiagnosticSystem.Diagnose(receivedList, accuracyLevel);

            return Ok(result.OrderByDescending(x => x.result));
        }

    }
}
