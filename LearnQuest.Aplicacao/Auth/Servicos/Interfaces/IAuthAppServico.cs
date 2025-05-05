using LearnQuest.DataTransfer.Auth.Request;
using LearnQuest.DataTransfer.Auth.Response;

namespace LearnQuest.Aplicacao.Auth.Servicos.Interfaces
{
    public interface IAuthAppServico
    {
        Task<AuthResponse> RegistrarAsync(RegisterRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);
        // Task<UserTypeResponse> ObterTipoUsuarioAsync(int userId);
    }
}