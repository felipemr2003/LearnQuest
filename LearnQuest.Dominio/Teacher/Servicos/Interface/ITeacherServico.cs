using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Teacher.Entidades;
using LearnQuest.Dominio.Teacher.Servicos.Comandos;

namespace LearnQuest.Dominio.Teacher.Servicos.Interface
{
    public interface ITeacherServico
    {
        Teacherss Instanciar(string name, string email, string passwordHash);
        Task<Teacherss> InserirAsync(TeacherInserirComando comando);
        Task VincularTurmaAsync(TeacherVincularTurmaComando comando);
    }
}