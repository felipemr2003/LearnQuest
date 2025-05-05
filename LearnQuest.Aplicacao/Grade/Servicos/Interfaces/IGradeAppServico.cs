using LearnQuest.DataTransfer.Grade.Request;
using LearnQuest.DataTransfer.Grade.Response;

namespace LearnQuest.Aplicacao.Grade.Servicos.Interfaces
{
    public interface IGradeAppServico
    {
        Task<GradeResponse> InserirAsync(GradeInserirRequest request);
        Task<IEnumerable<GradeResponse>> ListarAsync(GradeListarRequest request);
        Task<IEnumerable<StudentRankingResponse>> ObterRankingPorTurmaAsync(int turmaId);
    }
}