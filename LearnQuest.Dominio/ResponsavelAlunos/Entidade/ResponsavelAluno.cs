using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Usuarios.Entidades;

namespace LearnQuest.Dominio.ResponsavelAlunos.Entidade
{
    public class ResponsavelAluno
    {
        public virtual int ResponsavelId { get; protected set; }
        public virtual int AlunoId { get; protected set; }
        public virtual Usuario Responsavel { get; protected set; }
        public virtual Usuario Aluno { get; protected set; }

        public ResponsavelAluno(Usuario responsavel, Usuario aluno)
        {
            SetResponsavel(responsavel);
            SetAluno(aluno);
        }

        protected ResponsavelAluno()
        {

        }

        public virtual void SetResponsavel(Usuario responsavel)
        {
            Responsavel = responsavel;
        }
        public virtual void SetAluno(Usuario aluno)
        {
            Aluno = aluno;
        }
    }
}