using AutoMapper;
using LearnQuest.Aplicacao.Parent.Servicos.Interfaces;
using LearnQuest.DataTransfer.Parent.Request;
using LearnQuest.DataTransfer.Parent.Response;
using LearnQuest.DataTransfer.Students.Response;
using LearnQuest.Dominio.Interfaces;
using LearnQuest.Dominio.Parent.Entidades;
using LearnQuest.Dominio.Parent.Servicos.Comandos;
using LearnQuest.Dominio.Parent.Servicos.Interfaces;
using LearnQuest.Dominio.Student.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LearnQuest.Aplicacao.Parent.Servicos
{
    public class ParentAppServico : IParentAppServico
    {
        private readonly IParentServico parentServico;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepositorio<Parents> repositorioParent;
        private readonly IRepositorio<Students> repositorioStudent;

        public ParentAppServico(IParentServico parentServico, IMapper mapper, IUnitOfWork unitOfWork, IRepositorio<Parents> repositorioParent, IRepositorio<Students> repositorioStudent)
        {
            this.parentServico = parentServico;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repositorioParent = repositorioParent;
            this.repositorioStudent = repositorioStudent;
        }

        public async Task<ParentResponse> InserirAsync(ParentInserirRequest request)
        {
            try
            {
                ParentsInserirComando comando = mapper.Map<ParentsInserirComando>(request);
                await unitOfWork.BeginTransactionAsync();
                var parent = await parentServico.InserirAsync(comando);
                await unitOfWork.SalvarAlteracoesAsync();
                await unitOfWork.CommitAsync();
                return mapper.Map<ParentResponse>(parent);
            }
            catch
            {
                throw;
            }
        }

        // public async Task<IEnumerable<ParentResponse>> ListarAsync(ParentListarRequest request)
        // {
        //     // This method can be removed or refactored if not used
        //     throw new NotImplementedException();
        // }

        public async Task<IEnumerable<StudentsResponse>> ListarFilhosAsync(int parentId)
        {
            var query = repositorioStudent.Query().Where(s => s.ParentId == parentId);
            var students = await query.ToListAsync();
            return mapper.Map<IEnumerable<StudentsResponse>>(students);
        }
    }
}