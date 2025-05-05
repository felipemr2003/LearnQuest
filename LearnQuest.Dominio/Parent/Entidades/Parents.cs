using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Student.Entidades;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Parent.Entidades
{
    public class Parents
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string PasswordHash { get; protected set; }
        public ICollection<Students> Children { get; protected set; } = new List<Students>();

        public Parents(string name, string email, string passwordHash)
        {
            SetName(name);
            SetEmail(email);
            SetPasswordHash(passwordHash);
        }

        public virtual void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new RegraDeNegocioExcecao("Nome do responsável é obrigatório");

            if (name.Length > 255)
                throw new RegraDeNegocioExcecao("Nome deve ter no máximo 255 caracteres");

            Name = name;
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
            // if (string.IsNullOrWhiteSpace(passwordHash))
            //     throw new RegraDeNegocioExcecao("Hash da senha é obrigatório");

            PasswordHash = passwordHash;
        }
    }
}