using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Aplicacao.Class.Servicos.Interfaces;
using LearnQuest.DataTransfer.Class.Request;
using LearnQuest.DataTransfer.Class.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LearnQuest.API.Controllers.Class
{
    [ApiController]
    [Route("api/class")]
    public class ClassController : ControllerBase
    {
        private readonly IClassAppServico classAppServico;

        public ClassController(IClassAppServico classAppServico)
        {
            this.classAppServico = classAppServico;
        }

        [HttpPost]
        public async Task<ActionResult<ClasseResponse>> InserirAsync([FromBody] ClasseInserirRequest request)
        {
            var response = await classAppServico.InserirAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClasseResponse>>> ListarAsync([FromQuery] ClasseListarRequest request)
        {
            var response = await classAppServico.ListarAsync(request);
            return Ok(response);
        }

        [HttpGet("teacher/{teacherId}/students")]
        public async Task<ActionResult<IEnumerable<ClasseWithStudentsResponse>>> ListarComAlunosPorProfessorAsync(int teacherId)
        {
            var response = await classAppServico.ListarComAlunosPorProfessorAsync(teacherId);
            return Ok(response);
        }
    }
}