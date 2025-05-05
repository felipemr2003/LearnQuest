using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Student.Entidades;
using LearnQuest.Dominio.Subject.Entidades;
using LearnQuest.Dominio.Teacher.Entidades;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Grade.Entidades
{
    public class Grades
    {
        public int Id { get; set; }
        public decimal Score { get; set; }
        public DateTime DateAssigned { get; set; }

        public int StudentId { get; set; }
        public Students Student { get; set; }

        public int SubjectId { get; set; }
        public Subjects Subject { get; set; }

        public int TeacherId { get; set; }
        public Teacherss Teacher { get; set; }

        public Grades(decimal score, DateTime dateAssigned, Students student, Subjects subject, Teacherss teacher)
        {
            SetScore(score);
            SetDateAssigned(dateAssigned);
            SetStudent(student);
            SetSubject(subject);
            SetTeacher(teacher);
        }
        protected Grades()
        {

        }
        public virtual void SetScore(decimal score)
        {
            if (score < 0 || score > 10)
                throw new RegraDeNegocioExcecao("Nota deve estar entre 0 e 10");

            Score = score;
        }

        public virtual void SetDateAssigned(DateTime dateAssigned)
        {
            // if (dateAssigned > DateTime.UtcNow)
            //     throw new RegraDeNegocioExcecao("Data não pode ser futura");

            DateAssigned = dateAssigned;
        }

        public virtual void SetStudent(Students student)
        {
            Student = student ?? throw new RegraDeNegocioExcecao("Aluno é obrigatório");
        }

        public virtual void SetSubject(Subjects subject)
        {
            Subject = subject ?? throw new RegraDeNegocioExcecao("Matéria é obrigatória");
        }

        public virtual void SetTeacher(Teacherss teacher)
        {
            Teacher = teacher ?? throw new RegraDeNegocioExcecao("Professor é obrigatório");
        }
    }
}