using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LearnQuest.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LearnQuest.Infra.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly LearnQuestDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repositorio(LearnQuestDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
        public async Task<T> ObterPorIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> ListarTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AdicionarAsync(T entidade)
        {
            await _dbSet.AddAsync(entidade);
        }

        public async Task AtualizarAsync(T entidade)
        {
            _dbSet.Update(entidade);
            await Task.CompletedTask;
        }

        public async Task RemoverAsync(T entidade)
        {
            _dbSet.Remove(entidade);
            await Task.CompletedTask;
        }

        
    }
}