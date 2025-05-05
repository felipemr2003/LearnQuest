// using System.Linq.Expressions;
// using LearnQuest.Dominio.Filtros;
// using LearnQuest.Dominio.Repositorios.Interface;
// using LearnQuest.Dominio.Utils.Consultas;
// using LearnQuest.Dominio.Utils.Excecoes;
// using NHibernate;
// using NHibernate.Linq;
// using NHibernate.Util;
// using System.Linq.Dynamic.Core;
// using System.Linq.Dynamic.Core.Exceptions;

// namespace LearnQuest.Infra.Utils.Repositorios
// {
//     public class RepositorioNHibernate<T> : IRepositorioNHibernate<T> where T : class
//     {
//         protected readonly ISession session;

//         public RepositorioNHibernate(ISession session)
//         {
//             this.session = session;
//         }

//         public void Editar(T entidade)
//         {
//             session.Update(entidade);
//         }

//         public void Excluir(T entidade)
//         {
//             session.Delete(entidade);
//         }

//         public void Excluir(IEnumerable<T> entidades)
//         {
//             foreach (T entidade in entidades)
//             {
//                 session.Delete(entidade);
//             }
//         }

//         public void Inserir(T entidade)
//         {
//             session.Save(entidade);
//         }
//         public void Inserir(IEnumerable<T> entidades)
//         {
//             foreach (T entidade in entidades)
//             {
//                 session.Save(entidade);
//             }
//         }

//         public IQueryable<T> Query()
//         {
//             return session.Query<T>();
//         }

//         public IQueryable<T> QueryWithJoin(params Expression<Func<T, object>>[] entitySelectors)
//         {
//             if (entitySelectors == null || entitySelectors.Length == 0)
//             {
//                 return Query();
//             }

//             IQueryable<T> queryable = Query();
//             foreach (Expression<Func<T, object>> relatedObjectSelector in entitySelectors)
//             {
//                 queryable = queryable.Fetch(relatedObjectSelector);
//             }

//             return queryable;
//         }

//         public PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd)
//         {
//             try
//             {
//                 query = query.OrderBy(cpOrd + " " + tpOrd.ToString());
//                 return Paginar(query, qt, pg);
//             }
//             catch (ParseException)
//             {
//                 throw new RegraDeNegocioExcecao("Deu erro no tipo de ordenação");
//             }
//         }



//         public T Recuperar(int id)
//         {
//             return session.Get<T>(id);
//         }

//         private static PaginacaoConsulta<T> Paginar(IQueryable<T> query, int qt, int pg)
//         {
//             return new PaginacaoConsulta<T>
//             {
//                 Registros = query.Skip((pg - 1) * qt).Take(qt).ToList(),
//                 Total = query.LongCount(),
//             };
//         }
//     }
// }