using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnQuest.Dominio.Utils.Consultas
{
    public class PaginacaoConsulta<T> where T : class
    {
        public long Total { get; set; }
        public IEnumerable<T> Registros { get; set; }
    }
}