using LearnQuest.Aplicacao.Auth.Servicos.Interfaces;
using LearnQuest.DataTransfer.Auth.Request;
using LearnQuest.DataTransfer.Auth.Response;
using Microsoft.AspNetCore.Mvc;

namespace LearnQuest.API.Controllers.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppServico authAppServico;

        public AuthController(IAuthAppServico authAppServico)
        {
            this.authAppServico = authAppServico;
        }

        [HttpPost]
        public async Task<ActionResult<AuthResponse>> InserirAsync([FromBody] RegisterRequest request)
        {
            var response = await authAppServico.RegistrarAsync(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync([FromBody] LoginRequest request)
        {
            var response = await authAppServico.LoginAsync(request);
            return Ok(response);
        }

    }
}