using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.DataTransfer.Class.Request;
using LearnQuest.DataTransfer.Class.Response;

namespace LearnQuest.Aplicacao.Class.Servicos.Interfaces
{
    public interface IClassAppServico
    {
        Task<ClasseResponse> InserirAsync(ClasseInserirRequest request);
        Task<IEnumerable<ClasseResponse>> ListarAsync(ClasseListarRequest request);
    }
}