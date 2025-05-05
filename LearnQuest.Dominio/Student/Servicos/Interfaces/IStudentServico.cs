using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Class.Entidades;
using LearnQuest.Dominio.Parent.Entidades;
using LearnQuest.Dominio.Student.Entidades;
using LearnQuest.Dominio.Student.Servicos.Comandos;

namespace LearnQuest.Dominio.Student.Servicos.Interfaces
{
    public interface IStudentServico
    {
        Students Instanciar(string name, string email, string passwordHash, Parents parent, Classe classe);
        Task<Students> InserirAsync(StudentsInserirComando comando);
    }
}