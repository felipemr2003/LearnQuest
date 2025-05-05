using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnQuest.Dominio.Auth.Comandos;
using LearnQuest.Dominio.Auth.Servicos.Interfaces;
using LearnQuest.Dominio.Parent.Entidades;
using LearnQuest.Dominio.Parent.Servicos.Comandos;
using LearnQuest.Dominio.Parent.Servicos.Interfaces;
using LearnQuest.Dominio.Student.Entidades;
using LearnQuest.Dominio.Student.Servicos.Comandos;
using LearnQuest.Dominio.Student.Servicos.Interfaces;
using LearnQuest.Dominio.Teacher.Entidades;
using LearnQuest.Dominio.Teacher.Servicos.Comandos;
using LearnQuest.Dominio.Teacher.Servicos.Interface;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Dominio.Auth.Servicos
{
    public class AuthServico : IAuthServico
    {
        private readonly IParentServico parentServico;
        private readonly ITeacherServico teacherServico;
        private readonly IStudentServico studentServico;

        public AuthServico(IParentServico parentServico, ITeacherServico teacherServico, IStudentServico studentServico)
        {
            this.parentServico = parentServico;
            this.teacherServico = teacherServico;
            this.studentServico = studentServico;
        }

        public async Task<object> RegistrarAsync(RegisterComando comando)
        {
            return comando.TipoUsuario.ToLower() switch
            {
                "pai" => await RegistrarParentAsync(comando),
                "professor" => await RegistrarTeacherAsync(comando),
                "aluno" => await RegistrarStudentAsync(comando),
                _ => throw new RegraDeNegocioExcecao("Tipo de usuário inválido")
            };
        }

        private async Task<Parents> RegistrarParentAsync(RegisterComando comando)
        {
            var parentComando = new ParentsInserirComando(
                comando.Name,
                comando.Email,
                comando.PasswordHash
            );
            return await parentServico.InserirAsync(parentComando);
        }

        private async Task<Teacherss> RegistrarTeacherAsync(RegisterComando comando)
        {
            var teacherComando = new TeacherInserirComando(
                comando.Name,
                comando.Email,
                comando.PasswordHash
            );
            return await teacherServico.InserirAsync(teacherComando);
        }

        private async Task<Students> RegistrarStudentAsync(RegisterComando comando)
        {
            var studentComando = new StudentsInserirComando(
                comando.Name,
                comando.Email,
                comando.PasswordHash,
                comando.ParentId!.Value,
                comando.ClassId!.Value
            );
            return await studentServico.InserirAsync(studentComando);
        }
    }
}