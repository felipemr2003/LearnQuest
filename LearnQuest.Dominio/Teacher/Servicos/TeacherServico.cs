using LearnQuest.Dominio.Class.Entidades;
using LearnQuest.Dominio.Interfaces;
using LearnQuest.Dominio.Teacher.Entidades;
using LearnQuest.Dominio.Teacher.Servicos.Comandos;
using LearnQuest.Dominio.Teacher.Servicos.Interface;

namespace LearnQuest.Dominio.Teacher.Servicos
{
    public class TeacherServico : ITeacherServico
    {
        private readonly IRepositorio<Teacherss> repositorio;
        private readonly IRepositorio<Classe> repositorioClasse;

        public TeacherServico(IRepositorio<Teacherss> repositorio, IRepositorio<Classe> repositorioClasse)
        {
            this.repositorio = repositorio;
            this.repositorioClasse = repositorioClasse;
        }

        public Teacherss Instanciar(string name, string email, string passwordHash)
        {
            return new Teacherss(name, email, passwordHash);
        }

        public async Task<Teacherss> InserirAsync(TeacherInserirComando comando)
        {
            Teacherss teachers = Instanciar(comando.Name, comando.Email, comando.PasswordHash);
            await repositorio.AdicionarAsync(teachers);
            return teachers;
        }

        public async Task VincularTurmaAsync(TeacherVincularTurmaComando comando)
        {
            var teacher = await repositorio.ObterPorIdAsync(comando.TeacherId);
            var classe = await repositorioClasse.ObterPorIdAsync(comando.ClassId);

            teacher.Classes.Add(classe);
            await repositorio.AtualizarAsync(teacher);
        }

        
    }
}