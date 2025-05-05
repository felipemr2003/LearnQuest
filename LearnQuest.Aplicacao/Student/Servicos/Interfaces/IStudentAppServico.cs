using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.DataTransfer.Students.Request;
using LearnQuest.DataTransfer.Students.Response;

namespace LearnQuest.Aplicacao.Student.Servicos.Interfaces
{
    public interface IStudentAppServico
    {
        Task<IEnumerable<StudentsResponse>> ListarAsync(StudentListarRequest request);
    }
}