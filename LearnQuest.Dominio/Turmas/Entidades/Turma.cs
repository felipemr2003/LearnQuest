using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Usuarios.Entidades;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Turmas.Entidades
{
    public class Turma
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual Usuario ProfessorId { get; protected set; }
        public virtual string AnoLetivo { get; protected set; }
        public Turma(string nome, Usuario professorId, string anoLetivo)
        {
            SetNome(nome);
            SetProfessorId(professorId);
            SetAnoLetivo(anoLetivo);
        }

        protected Turma()
        {

        }
        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new RegraDeNegocioExcecao("Nome inválido");
            }
            Nome = nome;
        }
        public virtual void SetProfessorId(Usuario professorId)
        {
            ProfessorId = professorId;
        }
        public virtual void SetAnoLetivo(string anoLetivo)
        {
            AnoLetivo = anoLetivo;
        }
    }
}