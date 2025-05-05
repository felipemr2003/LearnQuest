using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Class.Entidades;
using LearnQuest.Dominio.Grade.Entidades;
using LearnQuest.Dominio.Parent.Entidades;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Student.Entidades
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int ParentId { get; set; }
        public Parents Parent { get; set; }

        public int ClassId { get; set; }
        public Classe Class { get; set; }

        public ICollection<Grades> Grades { get; set; } = new List<Grades>();

        public Students(string name, string email, string passwordHash, Parents parent, Classe classe)
        {
            SetName(name);
            SetParent(parent);
            SetClass(classe);
            SetEmail(email);
            SetPasswordHash(passwordHash);
        }
        protected Students()
        {

        }

        public virtual void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new RegraDeNegocioExcecao("Nome do aluno é obrigatório");

            if (name.Length > 255)
                throw new RegraDeNegocioExcecao("Nome deve ter no máximo 255 caracteres");

            Name = name;
        }

        public virtual void SetParent(Parents parent)
        {
            Parent = parent ?? throw new RegraDeNegocioExcecao("Responsável é obrigatório");
        }

        public virtual void SetClass(Classe classe)
        {
            Class = classe ?? throw new RegraDeNegocioExcecao("Turma é obrigatória");
        }

        public virtual void SetEmail(string email)
        {
            // if (string.IsNullOrWhiteSpace(email))
            //     throw new RegraDeNegocioExcecao("Email é obrigatório");

            // if (!new EmailAddressAttribute().IsValid(email))
            //     throw new RegraDeNegocioExcecao("Email inválido");

            Email = email;
        }

        public virtual void SetPasswordHash(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new RegraDeNegocioExcecao("Hash da senha é obrigatório");

            PasswordHash = passwordHash;
        }
    }
}