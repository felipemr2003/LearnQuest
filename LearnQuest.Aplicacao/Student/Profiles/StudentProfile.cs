using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearnQuest.DataTransfer.Students.Response;
using LearnQuest.Dominio.Student.Entidades;

namespace LearnQuest.Aplicacao.Student.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Students, StudentsResponse>()
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Name))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.Name));
        }
    }
}