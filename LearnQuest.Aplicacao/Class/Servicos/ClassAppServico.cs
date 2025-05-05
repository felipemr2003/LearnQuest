using AutoMapper;
using LearnQuest.Aplicacao.Class.Servicos.Interfaces;
using LearnQuest.DataTransfer.Class.Request;
using LearnQuest.DataTransfer.Class.Response;
using LearnQuest.Dominio.Class.Entidades;
using LearnQuest.Dominio.Class.Servicos.Comandos;
using LearnQuest.Dominio.Class.Servicos.Interfaces;
using LearnQuest.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LearnQuest.Aplicacao.Class.Servicos
{
    public class ClassAppServico : IClassAppServico
    {
        private readonly IMapper mapper;
        private readonly IClasseServico classeServico;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepositorio<Classe> classeRepositorio;

        public ClassAppServico(IMapper mapper, IClasseServico classeServico, IUnitOfWork unitOfWork, IRepositorio<Classe> classeRepositorio)
        {
            this.mapper = mapper;
            this.classeServico = classeServico;
            this.unitOfWork = unitOfWork;
            this.classeRepositorio = classeRepositorio;
        }

        public async Task<ClasseResponse> InserirAsync(ClasseInserirRequest request)
        {
            try
            {
                ClasseInserirComando comando = mapper.Map<ClasseInserirComando>(request);
                await unitOfWork.BeginTransactionAsync();
                var classe = await classeServico.InserirAsync(comando);
                await unitOfWork.SalvarAlteracoesAsync();
                await unitOfWork.CommitAsync();
                return mapper.Map<ClasseResponse>(classe);
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<ClasseResponse>> ListarAsync(ClasseListarRequest request)
        {

            var query = classeRepositorio.Query()
                    .Where(c => c.Teachers.Any(t => t.Id == request.TeacherId));


            if (request.Id.HasValue)
            {
                query = query.Where(c => c.Id == request.Id.Value);
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(c => c.Name.Contains(request.Name));
            }

            var classes = await query.ToListAsync();

            return mapper.Map<IEnumerable<ClasseResponse>>(classes);
        }
    }
}