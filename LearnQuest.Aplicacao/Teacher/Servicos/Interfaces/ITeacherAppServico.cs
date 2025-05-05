using LearnQuest.DataTransfer.Teachers.Request;
using LearnQuest.DataTransfer.Teachers.Response;
using LearnQuest.Dominio.Teacher.Entidades;

namespace LearnQuest.Aplicacao.Teacher.Servicos.Interfaces
{
    public interface ITeacherAppServico
    {
        Task VincularTurmaAsync(TeacherVincularTurmaRequest request);
        Task<List<TeacherClassesResponse>> ListarTurmasDoProfessorAsync(int teacherId);
        Task<List<TeacherClassesResponse>> ListarVinculosAsync();
        Task<IEnumerable<TeacherResponse>> ListarAsync(TeacherListarRequest request);
        // Task<Teacherss> ValidarCredenciaisAsync(string email, string senha);
    }
}