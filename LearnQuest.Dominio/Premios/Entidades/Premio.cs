using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Premios.Entidades
{
    public class Premio
    {
        public virtual int NivelNecessario { get; protected set; }
        public virtual string NomePremio { get; protected set; }
        public virtual string Descricao { get; protected set; }

        public Premio(int nivelNecessario, string nomePremio, string descricao)
        {
            SetNivelNecessario(nivelNecessario);
            SetNomePremio(nomePremio);
            SetDescricao(descricao);
        }
        protected Premio()
        {

        }

        public virtual void SetNivelNecessario(int nivelNecessario)
        {
            if (nivelNecessario < 1)
            {
                throw new RegraDeNegocioExcecao("Nivel inválido");
            }
            NivelNecessario = nivelNecessario;
        }

        public virtual void SetNomePremio(string nomePremio)
        {
            if (string.IsNullOrWhiteSpace(nomePremio))
            {
                throw new RegraDeNegocioExcecao("Nome inválido");
            }
            NomePremio = nomePremio;
        }

        public virtual void SetDescricao(string descricao)
        {
            Descricao = descricao;
        }
    }
}