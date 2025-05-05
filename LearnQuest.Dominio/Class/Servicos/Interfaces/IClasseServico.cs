using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Class.Entidades;
using LearnQuest.Dominio.Class.Servicos.Comandos;

namespace LearnQuest.Dominio.Class.Servicos.Interfaces
{
    public interface IClasseServico
    {
        Classe Instanciar(string name);
        Task<Classe> InserirAsync(ClasseInserirComando comando);
        Task<Classe> ValidarAsync(int id);
    }
}