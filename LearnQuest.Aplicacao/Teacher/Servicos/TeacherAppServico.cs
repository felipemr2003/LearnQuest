using AutoMapper;
using LearnQuest.Aplicacao.Teacher.Servicos.Interfaces;
using LearnQuest.DataTransfer.Teachers.Request;
using LearnQuest.DataTransfer.Teachers.Response;
using LearnQuest.Dominio.Interfaces;
using LearnQuest.Dominio.Teacher.Entidades;
using LearnQuest.Dominio.Teacher.Servicos.Comandos;
using LearnQuest.Dominio.Teacher.Servicos.Interface;
using Microsoft.EntityFrameworkCore;

namespace LearnQuest.Aplicacao.Teacher.Servicos
{
    public class TeacherAppServico : ITeacherAppServico
    {
        private readonly ITeacherServico teacherServico;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepositorio<Teacherss> repositorio;

        public TeacherAppServico(ITeacherServico teacherServico, IMapper mapper, IUnitOfWork unitOfWork, IRepositorio<Teacherss> repositorio)
        {
            this.teacherServico = teacherServico;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repositorio = repositorio;
        }

        public async Task VincularTurmaAsync(TeacherVincularTurmaRequest request)
        {
            try
            {
                var comando = mapper.Map<TeacherVincularTurmaComando>(request);
                await unitOfWork.BeginTransactionAsync();
                await teacherServico.VincularTurmaAsync(comando);
                await unitOfWork.SalvarAlteracoesAsync();
                await unitOfWork.CommitAsync();
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<List<TeacherClassesResponse>> ListarVinculosAsync()
        {
            return await repositorio.Query()
                .Include(t => t.Classes)
                .SelectMany(teacher => teacher.Classes,
                    (teacher, classe) => new TeacherClassesResponse
                    {
                        ProfessorNome = teacher.Name,
                        TurmaNome = classe.Name,
                        TurmaId = classe.Id
                    })
                .ToListAsync();
        }

        public async Task<List<TeacherClassesResponse>> ListarTurmasDoProfessorAsync(int teacherId)
        {
            return await repositorio
                .Query(t => t.Id == teacherId)
                .Include(t => t.Classes)
                .SelectMany(teacher => teacher.Classes,
                    (teacher, classe) => new TeacherClassesResponse
                    {
                        ProfessorNome = teacher.Name,
                        TurmaNome = classe.Name,
                        TurmaId = classe.Id
                    })
                .ToListAsync();
        }

        public async Task<IEnumerable<TeacherResponse>> ListarAsync(TeacherListarRequest request)
        {
            var query = repositorio.Query();

            if (request.Id != 0)
            {
                query = query.Where(t => t.Id == request.Id);
            }

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(t => t.Name == request.Name);
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                query = query.Where(t => t.Email == request.Email);
            }

            var teachers = await query
                .Select(t => new TeacherResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                    Email = t.Email,
                    PasswordHash = t.PasswordHash
                })
                .ToListAsync();

            return teachers;
        }

        // public async Task<Teacherss> ValidarCredenciaisAsync(string email, string senha)
        // {
        //     var professor = await repositorio.Query()
        //         .FirstOrDefaultAsync(t => t.Email == email);

        //     if (professor == null || professor.PasswordHash != senha)
        //         throw new Exception("Credenciais inválidas");

        //     return professor;
        // }
    }
}