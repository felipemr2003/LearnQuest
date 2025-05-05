using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Aplicacao.Grade.Servicos.Interfaces;
using LearnQuest.DataTransfer.Grade.Request;
using LearnQuest.DataTransfer.Grade.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LearnQuest.API.Controllers.Grade
{
    [ApiController]
    [Route("api/grades")]
    public class GradesController : ControllerBase
    {
        private readonly IGradeAppServico gradeAppServico;

        public GradesController(IGradeAppServico gradeAppServico)
        {
            this.gradeAppServico = gradeAppServico;
        }

        [HttpPost]
        public async Task<ActionResult<GradeResponse>> InserirAsync([FromBody] GradeInserirRequest request)
        {
            var response = await gradeAppServico.InserirAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeResponse>>> ListarAsync([FromQuery] GradeListarRequest request)
        {
            var response = await gradeAppServico.ListarAsync(request);
            return Ok(response);
        }

        [HttpGet("ranking/{turmaId}")]
        public async Task<ActionResult<IEnumerable<StudentRankingResponse>>> ObterRankingPorTurmaAsync(int turmaId)
        {
            var response = await gradeAppServico.ObterRankingPorTurmaAsync(turmaId);
            return Ok(response);
        }
    }
}