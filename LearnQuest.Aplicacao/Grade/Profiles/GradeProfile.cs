using AutoMapper;
using LearnQuest.DataTransfer.Grade.Request;
using LearnQuest.DataTransfer.Grade.Response;
using LearnQuest.Dominio.Grade.Entidades;
using LearnQuest.Dominio.Grade.Servicos.Comandos;

namespace LearnQuest.Aplicacao.Grade.Profiles
{
    public class GradeProfile : Profile
    {
        public GradeProfile()
        {
            CreateMap<Grades, GradeResponse>()
            .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.Name))
            .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.Name));
            CreateMap<GradeInserirRequest, GradesInserirComando>();
        }
    }
}