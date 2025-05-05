using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearnQuest.DataTransfer.Auth.Request;
using LearnQuest.DataTransfer.Auth.Response;
using LearnQuest.Dominio.Auth.Comandos;
using LearnQuest.Dominio.Parent.Entidades;
using LearnQuest.Dominio.Parent.Servicos.Comandos;
using LearnQuest.Dominio.Student.Entidades;
using LearnQuest.Dominio.Student.Servicos.Comandos;
using LearnQuest.Dominio.Teacher.Entidades;
using LearnQuest.Dominio.Teacher.Servicos.Comandos;

namespace LearnQuest.Aplicacao.Auth.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<Parents, AuthResponse>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(_ => "pai"));

            CreateMap<Teacherss, AuthResponse>()
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(_ => "professor"));

            CreateMap<Students, AuthResponse>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(_ => "aluno"));

            CreateMap<RegisterRequest, RegisterComando>();
            CreateMap<RegisterComando, ParentsInserirComando>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash));

            CreateMap<RegisterComando, TeacherInserirComando>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash));

            CreateMap<RegisterComando, StudentsInserirComando>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
            .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId!.Value))
            .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId!.Value));

            CreateMap<Teacherss, LoginResponse>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name));

            CreateMap<Parents, LoginResponse>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name));

            CreateMap<Students, LoginResponse>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name));
        }
    }
}