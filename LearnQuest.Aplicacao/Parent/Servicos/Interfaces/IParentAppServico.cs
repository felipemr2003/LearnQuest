using LearnQuest.DataTransfer.Parent.Response;
using LearnQuest.DataTransfer.Students.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearnQuest.Aplicacao.Parent.Servicos.Interfaces
{
    public interface IParentAppServico
    {
        Task<ParentResponse> InserirAsync(ParentInserirRequest request);
        Task<IEnumerable<StudentsResponse>> ListarFilhosAsync(int parentId);
    }
}
