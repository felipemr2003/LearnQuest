using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Usuarios.Entidades;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.ProgressoAlunos.Entidade
{
    public class ProgressoAluno
    {
        public virtual int AlunoId { get; protected set; }
        public virtual int NivelAtual { get; protected set; } = 1;
        public virtual int XpAtual { get; protected set; } = 0;
        public virtual string PremiosConquistados { get; protected set; }
        public virtual Usuario Aluno { get; protected set; }

        public ProgressoAluno(Usuario aluno)
        {
            SetAluno(aluno);
            PremiosConquistados = "";
        }

        protected ProgressoAluno()
        {

        }
        public virtual void SetAluno(Usuario aluno)
        {
            Aluno = aluno;
        }
        public virtual void SetPremiosConquistados(string premiosConquistados)
        {
            PremiosConquistados = premiosConquistados;
        }

        public virtual void SetNivelAtual(int nivelAtual)
        {
            if (nivelAtual < 1)
            {
                throw new RegraDeNegocioExcecao("Nivel inválido");
            }
            NivelAtual = nivelAtual;
        }
    }
}