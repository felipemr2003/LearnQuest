using AutoMapper;
using LearnQuest.DataTransfer.Teachers.Request;
using LearnQuest.DataTransfer.Teachers.Response;
using LearnQuest.Dominio.Teacher.Entidades;
using LearnQuest.Dominio.Teacher.Servicos.Comandos;

namespace LearnQuest.Aplicacao.Teacher.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<TeacherVincularTurmaRequest, TeacherVincularTurmaComando>();
            CreateMap<Teacherss, TeacherResponse>();
        }
    }
}