using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnQuest.Aplicacao.Utils.Transacoes.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Rollback();
        void Commit();
        void Limpar();
        void Flush();
    }
}