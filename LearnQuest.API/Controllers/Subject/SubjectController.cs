using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearnQuest.Aplicacao.Subject.Servicos.Interfaces;
using LearnQuest.DataTransfer.Subject.Response;

namespace LearnQuest.API.Controllers.Subject
{
    [ApiController]
    [Route("api/subject")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectAppServico subjectAppServico;

        public SubjectController(ISubjectAppServico subjectAppServico)
        {
            this.subjectAppServico = subjectAppServico;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<SubjectResponse>>> Listar()
        {
            var subjects = await subjectAppServico.Listar();
            return Ok(subjects);
        }
    }
}
