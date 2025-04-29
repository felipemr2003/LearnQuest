using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Aplicacao.Parent.Servicos.Interfaces;
using LearnQuest.DataTransfer.Parent.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LearnQuest.API.Controllers.Parent
{
    [ApiController]
    [Route("api/parent")]
    public class ParentController : ControllerBase
    {
        private readonly IParentAppServico parentAppServico;

        public ParentController(IParentAppServico parentAppServico)
        {
            this.parentAppServico = parentAppServico;
        }

        [HttpPost]
        public async Task<ActionResult<ParentResponse>> InserirAsync([FromBody] ParentInserirRequest request)
        {
            var response = await parentAppServico.InserirAsync(request);
            return Ok(response);
        }
    }
}