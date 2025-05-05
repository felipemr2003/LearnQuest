using System.Linq.Expressions;

namespace LearnQuest.Dominio.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        IQueryable<T> Query();
        IQueryable<T> Query(Expression<Func<T, bool>> predicate);
        IQueryable<T> Query(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> ObterPorIdAsync(int id);
        Task<IEnumerable<T>> ListarTodosAsync();
        Task AdicionarAsync(T entidade);
        Task AtualizarAsync(T entidade);
        Task RemoverAsync(T entidade);
    }
}