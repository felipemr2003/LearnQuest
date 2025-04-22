using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Filtros;
using LearnQuest.Dominio.Utils.Consultas;

namespace LearnQuest.Dominio.Repositorios.Interface
{
    public interface IRepositorioNHibernate<T> where T : class
    {
        void Inserir(T entidade);
        void Inserir(IEnumerable<T> entidades);
        void Editar(T entidade);
        void Excluir(T entidade);
        void Excluir(IEnumerable<T> entidades);
        T Recuperar(int id);
        IQueryable<T> Query();
        PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd);
    }
}