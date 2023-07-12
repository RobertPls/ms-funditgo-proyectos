using Domain.Repository.Proyectos;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCase.Command.Proyectos.AceptarProyecto
{
    public class AceptarProyectoHandler : IRequestHandler<AceptarProyectoCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AceptarProyectoHandler(IProyectoRepository proyectoRepository, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(AceptarProyectoCommand request, CancellationToken cancellationToken)
        {
            var proyecto = await _proyectoRepository.FindByIdAsync(request.ProyectoId);

            if (proyecto == null)
            {
                throw new BussinessRuleValidationException("Proyecto no encontrado");
            }
            proyecto.AceptarProyecto();

            await _proyectoRepository.UpdateAsync(proyecto);

            await _unitOfWork.Commit();

            return proyecto.Id;
        }
    }
}
