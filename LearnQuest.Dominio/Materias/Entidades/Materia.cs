using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Materias.Entidades
{
    public class Materia
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public Materia(string nome)
        {
            SetNome(nome);
        }
        protected Materia()
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
    }
}