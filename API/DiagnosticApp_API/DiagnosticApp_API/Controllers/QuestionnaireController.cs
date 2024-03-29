﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiagnosticApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnaireController : ControllerBase
    {
        private readonly DiagnosticAppContext _context;

        public QuestionnaireController(DiagnosticAppContext context)
        {
            _context = context;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Questionnaire>>> GetQuestionnaire()
        {
            return Ok(await _context.Questionnaires.ToListAsync());
        }
    }
}
