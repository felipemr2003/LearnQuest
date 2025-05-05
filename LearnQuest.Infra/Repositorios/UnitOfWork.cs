using LearnQuest.Dominio.Interfaces;

namespace LearnQuest.Infra.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LearnQuestDbContext _context;

        public UnitOfWork(LearnQuestDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public async Task<int> SalvarAlteracoesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}