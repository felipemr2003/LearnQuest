using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Aplicacao.Utils.Transacoes.Interfaces;
using NHibernate;

namespace LearnQuest.Aplicacao.Utils.Transacoes
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ISession session;
        private ITransaction transaction;

        public UnitOfWork(ISession session)
        {
            this.session = session;
        }

        public void BeginTransaction()
        {
            this.transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null && transaction.IsActive)
            {
                transaction.Commit();
            }
        }

        public void Rollback()
        {
            if (transaction != null && transaction.IsActive)
            {
                transaction.Rollback();
            }
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
            if (session != null && session.IsOpen)
            {
                session.Close();
                session = null;
            }
        }

        public void Limpar()
        {
            if (session != null)
                session.Clear();
        }

        public void Flush()
        {
            if (session != null)
                session.Flush();
        }
    }
}