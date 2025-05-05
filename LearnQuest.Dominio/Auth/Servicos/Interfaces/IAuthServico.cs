using LearnQuest.Dominio.Auth.Comandos;

namespace LearnQuest.Dominio.Auth.Servicos.Interfaces
{
    public interface IAuthServico
    {
        Task<object> RegistrarAsync(RegisterComando comando);
    }
}