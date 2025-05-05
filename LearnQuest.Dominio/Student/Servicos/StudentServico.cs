using LearnQuest.Dominio.Class.Entidades;
using LearnQuest.Dominio.Class.Servicos.Interfaces;
using LearnQuest.Dominio.Interfaces;
using LearnQuest.Dominio.Parent.Entidades;
using LearnQuest.Dominio.Parent.Servicos.Interfaces;
using LearnQuest.Dominio.Student.Entidades;
using LearnQuest.Dominio.Student.Servicos.Comandos;
using LearnQuest.Dominio.Student.Servicos.Interfaces;

namespace LearnQuest.Dominio.Student.Servicos
{
    public class StudentServico : IStudentServico
    {
        public readonly IRepositorio<Students> repositorio;
        private readonly IParentServico parentServico;
        private readonly IClasseServico classeServico;

        public StudentServico(IRepositorio<Students> repositorio, IParentServico parentServico, IClasseServico classeServico)
        {
            this.repositorio = repositorio;
            this.parentServico = parentServico;
            this.classeServico = classeServico;
        }

        public Students Instanciar(string name, string email, string passwordHash, Parents parent, Classe classe)
        {
            return new Students(name, email, passwordHash, parent, classe);
        }

        public async Task<Students> InserirAsync(StudentsInserirComando comando)
        {
            Classe classe = await classeServico.ValidarAsync(comando.ClassId);
            Parents parents = await parentServico.ValidarAsync(comando.ParentId);

            Students students = Instanciar(comando.Name, comando.Email, comando.PasswordHash, parents, classe);
            await repositorio.AdicionarAsync(students);
            return students;
        }
    }
}