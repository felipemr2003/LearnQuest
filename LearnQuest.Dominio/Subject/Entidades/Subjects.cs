using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Grade.Entidades;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Subject.Entidades
{
    public class Subjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Grades> Grades { get; set; } = new List<Grades>();

        public Subjects(string name)
        {
            SetName(name);
        }

        public virtual void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new RegraDeNegocioExcecao("Nome da matéria é obrigatório");

            if (name.Length > 255)
                throw new RegraDeNegocioExcecao("Nome da matéria deve ter no máximo 255 caracteres");

            Name = name;
        }
    }
}