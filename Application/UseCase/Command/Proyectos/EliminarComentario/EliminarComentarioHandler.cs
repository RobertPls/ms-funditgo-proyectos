using Application.UseCase.Command.Proyectos.EliminarColaborador;
using Domain.Repository.Proyectos;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCase.Command.Proyectos.AgregarColaborador
{
    public class EliminarComentarioHandker : IRequestHandler<EliminarComentarioCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarComentarioHandker(IProyectoRepository proyectoRepository, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarComentarioCommand request, CancellationToken cancellationToken)
        {
            var proyecto = await _proyectoRepository.FindByIdAsync(request.ProyectoId);

            if (proyecto == null)
            {
                throw new BussinessRuleValidationException("Proyecto no encontrado");
            }

            if (!proyecto.EsCreadorDelComentarioOAdministrador(request.EjecutorId, request.ComentarioId))
            {
                throw new BussinessRuleValidationException("No eres tienes permisos para eliminar el comentario");
            }

            proyecto.EliminarComentario(request.ComentarioId);

            await _proyectoRepository.UpdateAsync(proyecto);

            await _unitOfWork.Commit();

            return proyecto.Id;
        }
    }
}
