using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Aplicacao.Student.Servicos.Interfaces;
using LearnQuest.DataTransfer.Students.Request;
using LearnQuest.DataTransfer.Students.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LearnQuest.API.Controllers.Students
{
    [ApiController]
    [Route("api/students")]

    public class StudentsController : ControllerBase
    {
        private readonly IStudentAppServico studentAppServico;
        public StudentsController(IStudentAppServico studentAppServico)
        {
            this.studentAppServico = studentAppServico;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsResponse>>> ListarAsync([FromQuery] StudentListarRequest request)
        {
            var response = await studentAppServico.ListarAsync(request);
            return Ok(response);
        }
    }
}