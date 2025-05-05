using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearnQuest.Aplicacao.Grade.Servicos.Interfaces;
using LearnQuest.DataTransfer.Grade.Request;
using LearnQuest.DataTransfer.Grade.Response;
using LearnQuest.Dominio.Grade.Entidades;
using LearnQuest.Dominio.Grade.Servicos.Comandos;
using LearnQuest.Dominio.Grade.Servicos.Interfaces;
using LearnQuest.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LearnQuest.Aplicacao.Grade.Servicos
{
    public class GradeAppServico : IGradeAppServico
    {
        private readonly IMapper mapper;
        private readonly IGradeServico gradeServico;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepositorio<Grades> repositorioGrade;
        private readonly LearnQuest.Infra.LearnQuestDbContext dbContext;

        public GradeAppServico(IMapper mapper, IGradeServico gradeServico, IUnitOfWork unitOfWork, IRepositorio<Grades> repositorioGrade, LearnQuest.Infra.LearnQuestDbContext dbContext)
        {
            this.mapper = mapper;
            this.gradeServico = gradeServico;
            this.unitOfWork = unitOfWork;
            this.repositorioGrade = repositorioGrade;
            this.dbContext = dbContext;
        }

        public async Task<GradeResponse> InserirAsync(GradeInserirRequest request)
        {
            try
            {
                await unitOfWork.BeginTransactionAsync();

                // Talvez colocar uma validação para só professores conseguirem inserir nota!!

                var comando = mapper.Map<GradesInserirComando>(request);
                var grade = await gradeServico.InserirAsync(comando);

                await unitOfWork.SalvarAlteracoesAsync();
                await unitOfWork.CommitAsync();

                return mapper.Map<GradeResponse>(grade);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<GradeResponse>> ListarAsync(GradeListarRequest request)
        {
            var query = repositorioGrade.Query()
                    .Include(g => g.Student)
                    .Include(g => g.Subject)
                    .Include(g => g.Teacher)
                    .AsQueryable();


            if (request.StudentId != 0)
            {
                query = query.Where(g => g.StudentId == request.StudentId);
            }

            // Filtros adicionais   
            if (request.Id != 0)
            {
                query = query.Where(g => g.Id == request.Id);
            }

            if (request.Score > 0)
            {
                query = query.Where(g => g.Score == request.Score);
            }

            if (request.SubjectId != 0)
            {
                query = query.Where(g => g.SubjectId == request.SubjectId);
            }

            if (request.TeacherId != 0)
            {
                query = query.Where(g => g.TeacherId == request.TeacherId);
            }

            if (request.DateAssigned != default)
            {
                query = query.Where(g => g.DateAssigned.Date == request.DateAssigned.Date);
            }

            var grades = await query.ToListAsync();
            return mapper.Map<IEnumerable<GradeResponse>>(grades);
        }

        public async Task<IEnumerable<StudentRankingResponse>> ObterRankingPorTurmaAsync(int turmaId)
        {
            var query = repositorioGrade.Query()
                .Where(g => g.SubjectId == turmaId)
                .AsQueryable();

            var grouped = await query
                .GroupBy(g => g.StudentId)
                .Select(g => new
                {
                    StudentId = g.Key,
                    TotalScore = g.Sum(x => x.Score)
                })
                .OrderByDescending(r => r.TotalScore)
                .ToListAsync();

            var studentIds = grouped.Select(g => g.StudentId).ToList();

            var students = await dbContext.Students
                .Where(s => studentIds.Contains(s.Id))
                .ToListAsync();

            var result = grouped.Select(g =>
            {
                var student = students.FirstOrDefault(s => s.Id == g.StudentId);
                return new StudentRankingResponse
                {
                    StudentId = g.StudentId,
                    StudentName = student != null ? student.Name : "Unknown",
                    TotalScore = g.TotalScore
                };
            }).OrderByDescending(r => r.TotalScore).ToList();

            int rank = 1;
            foreach (var item in result)
            {
                item.Rank = rank++;
            }

            return result;
        }
    }
}