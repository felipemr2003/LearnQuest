using LearnQuest.Dominio.Usuarios.Enumeradores;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Usuarios.Entidades
{
    public class Usuario
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Senha { get; protected set; }
        public virtual TipoPerfil Perfil { get; protected set; }
        public virtual DateTime DataCadastro { get; protected set; }
        protected Usuario()
        {

        }

        public Usuario(string nome, string email, string senha, TipoPerfil perfil)
        {
            SetNome(nome);
            SetEmaiL(email);
            SetSenha(senha);
            SetPerfil(perfil);
            SetDataCadastro(DateTime.Now);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new RegraDeNegocioExcecao("Nome inválido");
            }
            Nome = nome;
        }

        public virtual void SetEmaiL(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new RegraDeNegocioExcecao("Email inválido");
            }
            Email = email;
        }

        public virtual void SetSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new RegraDeNegocioExcecao("Senha inválida");
            }
            Senha = senha;
        }
        public virtual void SetPerfil(TipoPerfil perfil)
        {
            Perfil = perfil;
        }
        public virtual void SetDataCadastro(DateTime dataCadastro)
        {
            if (dataCadastro.Date == DateTime.MinValue.Date)
            {
                throw new RegraDeNegocioExcecao("Data inválida");
            }
            DataCadastro = dataCadastro;
        }
    }
}