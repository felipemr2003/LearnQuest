using LearnQuest.Aplicacao.Teacher.Servicos.Interfaces;
using LearnQuest.DataTransfer.Teachers.Request;
using Microsoft.AspNetCore.Mvc;

namespace LearnQuest.API.Controllers.Teachers
{
    [ApiController]
    [Route("api/teacher")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherAppServico teacherAppServico;

        public TeachersController(ITeacherAppServico teacherAppServico)
        {
            this.teacherAppServico = teacherAppServico;
        }

        /// <summary>
        /// Vincula um professor a uma turma.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> VincularTurmaAsync(TeacherVincularTurmaRequest request)
        {
            await teacherAppServico.VincularTurmaAsync(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ListarAsync()
        {
            var response = await teacherAppServico.ListarVinculosAsync();
            return Ok(response);
        }

        [HttpGet("listarPorProfessor")]
        public async Task<IActionResult> ListarPorProfessorAsync(int idTeacher)
        {
            var response = await teacherAppServico.ListarTurmasDoProfessorAsync(idTeacher);
            return Ok(response);
        }
    }
}