using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Grade.Entidades;
using LearnQuest.Dominio.Grade.Servicos.Comandos;
using LearnQuest.Dominio.Grade.Servicos.Interfaces;
using LearnQuest.Dominio.Interfaces;
using LearnQuest.Dominio.Student.Entidades;
using LearnQuest.Dominio.Subject.Entidades;
using LearnQuest.Dominio.Teacher.Entidades;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Grade.Servicos
{
    public class GradeServico : IGradeServico
    {
        private readonly IRepositorio<Students> repositorioStudents;
        private readonly IRepositorio<Subjects> repositorioSubject;
        private readonly IRepositorio<Teacherss> repositorioTechers;
        private readonly IRepositorio<Grades> repositorioGrades;

        public GradeServico(IRepositorio<Students> repositorioStudents, IRepositorio<Subjects> repositorioSubject, IRepositorio<Teacherss> repositorioTechers, IRepositorio<Grades> repositorioGrades)
        {
            this.repositorioStudents = repositorioStudents;
            this.repositorioSubject = repositorioSubject;
            this.repositorioTechers = repositorioTechers;
            this.repositorioGrades = repositorioGrades;
        }

        public async Task<Grades> InserirAsync(GradesInserirComando comando)
        {
            var student = await repositorioStudents.ObterPorIdAsync(comando.StudentId)
                ?? throw new RegraDeNegocioExcecao("Aluno não encontrado");

            var subject = await repositorioSubject.ObterPorIdAsync(comando.SubjectId)
                ?? throw new RegraDeNegocioExcecao("Matéria não encontrada");

            var teacher = await repositorioTechers.ObterPorIdAsync(comando.TeacherId)
                ?? throw new RegraDeNegocioExcecao("Professor não encontrado");


            var grade = new Grades(
                comando.Score,
                comando.DateAssigned,
                student,
                subject,
                teacher
            );

            await repositorioGrades.AdicionarAsync(grade);
            return grade;
        }
    }
}