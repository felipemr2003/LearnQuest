using LearnQuest.Dominio.Grade.Entidades;
using LearnQuest.Dominio.Grade.Servicos.Comandos;

namespace LearnQuest.Dominio.Grade.Servicos.Interfaces
{
    public interface IGradeServico
    {
        Task<Grades> InserirAsync(GradesInserirComando comando);
    }
}