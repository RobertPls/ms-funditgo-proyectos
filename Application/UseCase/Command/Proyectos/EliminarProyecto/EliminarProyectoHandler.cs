using Domain.Repository.Proyectos;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCase.Command.Proyectos.EliminarProyecto
{
    public class EliminarProyectoHandler : IRequestHandler<EliminarProyectoCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarProyectoHandler(IProyectoRepository proyectoRepository, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarProyectoCommand request, CancellationToken cancellationToken)
        {
            var proyecto = await _proyectoRepository.FindByIdAsync(request.ProyectoId);

            if (proyecto == null)
            {
                throw new BussinessRuleValidationException("Proyecto no encontrado");
            }

            await _proyectoRepository.RemoveAsync(proyecto);

            await _unitOfWork.Commit();

            return proyecto.Id;
        }
    }
}
