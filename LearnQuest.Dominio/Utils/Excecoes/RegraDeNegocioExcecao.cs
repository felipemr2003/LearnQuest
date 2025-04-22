using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LearnQuest.Dominio.Utils.Excecoes
{
    public class RegraDeNegocioExcecao : Exception
    {   
        public RegraDeNegocioExcecao()
        {
            
        }

        public RegraDeNegocioExcecao(string mensagem) : base(mensagem)
        {
            
        }

        public RegraDeNegocioExcecao(string message, Exception innerException) : base(message, innerException)
        {
            
        }

        protected RegraDeNegocioExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            
        }
    }
}