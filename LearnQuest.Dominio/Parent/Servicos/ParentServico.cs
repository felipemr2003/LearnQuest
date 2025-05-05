using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Interfaces;
using LearnQuest.Dominio.Parent.Entidades;
using LearnQuest.Dominio.Parent.Servicos.Comandos;
using LearnQuest.Dominio.Parent.Servicos.Interfaces;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Parent.Servicos
{
    public class ParentServico : IParentServico
    {
        private readonly IRepositorio<Parents> repositorio;

        public ParentServico(IRepositorio<Parents> repositorio)
        {
            this.repositorio = repositorio;
        }

        public Parents Instanciar(string name, string email, string passwordHash)
        {
            return new Parents(name, email, passwordHash);
        }

        public async Task<Parents> InserirAsync(ParentsInserirComando comando)
        {
            Parents parents = Instanciar(comando.Name, comando.Email, comando.PasswordHash);
            await repositorio.AdicionarAsync(parents);
            return parents;
        }

        public async Task<Parents> ValidarAsync(int id)
        {
            var validar = await repositorio.ObterPorIdAsync(id);
            if (validar == null)
            {
                throw new RegraDeNegocioExcecao("Parente não encontrado");
            }
            return validar;
        }

    }
}