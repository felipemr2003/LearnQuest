using AutoMapper;
using LearnQuest.DataTransfer.Class.Request;
using LearnQuest.DataTransfer.Class.Response;
using LearnQuest.Dominio.Class.Entidades;
using LearnQuest.Dominio.Class.Servicos.Comandos;

namespace LearnQuest.Aplicacao.Class.Profiles
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Classe, ClasseResponse>()
            .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students.Count))  // Mapeia a quantidade de Students
            .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers.Count));
            CreateMap<ClasseInserirRequest, ClasseInserirComando>();
        }
    }
}