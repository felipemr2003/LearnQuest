using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearnQuest.DataTransfer.Parent.Response;
using LearnQuest.Dominio.Parent.Entidades;
using LearnQuest.Dominio.Parent.Servicos.Comandos;

namespace LearnQuest.Aplicacao.Parent.Profiles
{
    public class ParentProfile : Profile
    {
        public ParentProfile()
        {
            CreateMap<Parents, ParentResponse>()
            .ForMember(dest => dest.Children, opt =>
                opt.MapFrom(src => src.Children));
            CreateMap<ParentInserirRequest, ParentsInserirComando>();
        }
    }
}