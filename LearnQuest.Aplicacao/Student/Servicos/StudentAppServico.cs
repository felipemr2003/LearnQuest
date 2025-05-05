using AutoMapper;
using FluentNHibernate.Conventions;
using LearnQuest.Aplicacao.Student.Servicos.Interfaces;
using LearnQuest.DataTransfer.Students.Request;
using LearnQuest.DataTransfer.Students.Response;
using LearnQuest.Dominio.Interfaces;
using LearnQuest.Dominio.Student.Entidades;
using LearnQuest.Dominio.Student.Servicos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LearnQuest.Aplicacao.Student.Servicos
{
    public class StudentAppServico : IStudentAppServico
    {
        private readonly IMapper mapper;
        private readonly IRepositorio<Students> repositorioStudents;
        private readonly IStudentServico studentServico;
        private readonly IUnitOfWork unitOfWork;

        public StudentAppServico(IMapper mapper, IRepositorio<Students> repositorioStudents, IStudentServico studentServico, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repositorioStudents = repositorioStudents;
            this.studentServico = studentServico;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<StudentsResponse>> ListarAsync(StudentListarRequest request)
        {
            var query = repositorioStudents.Query();

            if (request.Id != 0)
            {
                query = query.Where(g => g.Id == request.Id);
            }

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(g => g.Name == request.Name);
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                query = query.Where(g => g.Email == request.Email);
            }

            if (request.ParentId != 0)
            {
                query = query.Where(g => g.ParentId == request.ParentId);
            }
            if (request.ClassId != 0)
            {
                query = query.Where(g => g.ClassId == request.ClassId);
            }

            var students = await query
                .Select(s => new StudentsResponse
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    PasswordHash = s.PasswordHash,
                    ParentId = s.ParentId,
                    ParentName = s.Parent.Name,
                    ClassId = s.ClassId,
                    ClassName = s.Class.Name
                })
                .ToListAsync();

            return students;
        }
    }
}