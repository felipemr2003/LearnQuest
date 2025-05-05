using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearnQuest.Aplicacao.Auth.Servicos.Interfaces;
using LearnQuest.Aplicacao.Teacher.Servicos;
using LearnQuest.DataTransfer.Auth.Request;
using LearnQuest.DataTransfer.Auth.Response;
using LearnQuest.Dominio.Auth.Comandos;
using LearnQuest.Dominio.Auth.Servicos.Interfaces;
using LearnQuest.Dominio.Interfaces;
using LearnQuest.Dominio.Parent.Entidades;
using LearnQuest.Dominio.Student.Entidades;
using LearnQuest.Dominio.Teacher.Entidades;
using LearnQuest.Dominio.Utils.Excecoes;

namespace LearnQuest.Aplicacao.Auth.Servicos
{
    public class AuthAppServicos : IAuthAppServico
    {
        private readonly IAuthServico authServico;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly TeacherAppServico teacherAppServico;
        private readonly IRepositorio<Teacherss> repositorioTeacher;
        private readonly IRepositorio<Parents> repositorioParents;
        private readonly IRepositorio<Students> repositorioStudents;

        public AuthAppServicos(IAuthServico authServico, IMapper mapper, IUnitOfWork unitOfWork, IRepositorio<Teacherss> repositorioTeacher, IRepositorio<Parents> repositorioParents, IRepositorio<Students> repositorioStudents)
        {
            this.authServico = authServico;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repositorioTeacher = repositorioTeacher;
            this.repositorioParents = repositorioParents;
            this.repositorioStudents = repositorioStudents;
        }

        public async Task<AuthResponse> RegistrarAsync(RegisterRequest request)
        {
            try
            {
                var comando = mapper.Map<RegisterComando>(request);

                var usuario = await authServico.RegistrarAsync(comando);

                await unitOfWork.BeginTransactionAsync();
                await unitOfWork.SalvarAlteracoesAsync();
                await unitOfWork.CommitAsync();

                return mapper.Map<AuthResponse>(usuario);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            try
            {
                // Tentar encontrar o usuário em cada serviço
                // var professor = await teacherAppServico.ValidarCredenciaisAsync(request.Email, request.Senha);
                var professor = repositorioTeacher.Query()
                    .FirstOrDefault(t => t.Email == request.Email);

                if (professor != null && professor.PasswordHash == request.Senha)
                    return MapearProfessor(professor);

                var pai = repositorioParents.Query()
                                    .FirstOrDefault(p => p.Email == request.Email);

                if (pai != null && pai.PasswordHash == request.Senha)
                    return MapearPai(pai);

                var aluno = repositorioStudents.Query(
                        s => s.Email == request.Email
                    ).FirstOrDefault();

                if (aluno != null && aluno.PasswordHash == request.Senha)
                    return MapearAluno(aluno);

                throw new Exception("Credenciais inválidas");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private LoginResponse MapearProfessor(Teacherss professor)
        {
            var response = mapper.Map<LoginResponse>(professor);
            response.TipoUsuario = "professor";
            return response;
        }

        private LoginResponse MapearPai(Parents pai)
        {
            var response = mapper.Map<LoginResponse>(pai);
            response.TipoUsuario = "pai";
            return response;
        }

        private LoginResponse MapearAluno(Students aluno)
        {
            var response = mapper.Map<LoginResponse>(aluno);
            response.TipoUsuario = "aluno";
            response.ParentId = aluno.Parent?.Id;
            response.ClassId = aluno.Class?.Id;
            return response;
        }

        // public async Task<UserTypeResponse> ObterTipoUsuarioAsync(int userId)
        // {
        //     var teacher = await repositorioTeacher.ObterPorIdAsync(userId);
        //     if (teacher != null)
        //     {
        //         return new UserTypeResponse { TipoUsuario = "teacher" };
        //     }

        //     var student = await repositorioStudents.ObterPorIdAsync(userId);
        //     if (student != null)
        //     {
        //         return new UserTypeResponse { TipoUsuario = "student" };
        //     }

        //     var parent = await repositorioParents.ObterPorIdAsync(userId);
        //     if (parent != null)
        //     {
        //         return new UserTypeResponse { TipoUsuario = "parent" };
        //     }

        //     throw new RegraDeNegocioExcecao("Usuário não encontrado");
        // }
    }
}