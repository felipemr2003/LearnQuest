using LearnQuest.Dominio.Class.Entidades;
using LearnQuest.Dominio.Class.Servicos.Comandos;
using LearnQuest.Dominio.Class.Servicos.Interfaces;
using LearnQuest.Dominio.Interfaces;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Class.Servicos
{
    public class ClasseServico : IClasseServico
    {
        private readonly IRepositorio<Classe> repositorio;

        public ClasseServico(IRepositorio<Classe> repositorio)
        {
            this.repositorio = repositorio;
        }

        public Classe Instanciar(string name)
        {
            return new Classe(name);
        }

        public async Task<Classe> InserirAsync(ClasseInserirComando comando)
        {
            Classe classe = Instanciar(comando.Name);
            await repositorio.AdicionarAsync(classe);
            return classe;
        }

        public async Task<Classe> ValidarAsync(int id)
        {
            var validar = await repositorio.ObterPorIdAsync(id);
            if (validar == null)
            {
                throw new RegraDeNegocioExcecao("Classe não encontrada");
            }
            return validar;
        }
    }
}