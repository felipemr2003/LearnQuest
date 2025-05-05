using LearnQuest.Dominio.Parent.Entidades;
using LearnQuest.Dominio.Parent.Servicos.Comandos;

namespace LearnQuest.Dominio.Parent.Servicos.Interfaces
{
    public interface IParentServico
    {
        Parents Instanciar(string name, string email, string passwordHash);
        Task<Parents> InserirAsync(ParentsInserirComando comando);
        Task<Parents> ValidarAsync(int id);
    }
}