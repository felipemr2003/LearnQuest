using LearnQuest.Dominio.Class.Entidades;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Teacher.Entidades
{
    public class Teacherss
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<Classe> Classes { get; set; } = new List<Classe>();

        public Teacherss(string name, string email, string passwordHash)
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
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new RegraDeNegocioExcecao("Hash da senha é obrigatório");

            PasswordHash = passwordHash;
        }

    }
}