using LearnQuest.Dominio.Student.Entidades;
using LearnQuest.Dominio.Teacher.Entidades;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Class.Entidades
{
    public class Classe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Students> Students { get; set; } = new List<Students>();
        public ICollection<Teacherss> Teachers { get; set; } = new List<Teacherss>();

        public Classe(string name)
        {
            SetName(name);
        }

        public virtual void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new RegraDeNegocioExcecao("Nome da turma é obrigatório");

            if (name.Length > 255)
                throw new RegraDeNegocioExcecao("Nome da turma deve ter no máximo 255 caracteres");

            Name = name;
        }

    }
}