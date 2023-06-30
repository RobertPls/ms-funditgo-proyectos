using Application.UseCase.Command.Proyectos.EnviarProyectoARevision;
using Domain.Repository.Proyectos;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCase.Command.Proyectos.EnviarProyectoAObservacion
{
    public class EnviarProyectoAObservacionHandler : IRequestHandler<EnviarProyectoAObservacionCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EnviarProyectoAObservacionHandler(IProyectoRepository proyectoRepository, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EnviarProyectoAObservacionCommand request, CancellationToken cancellationToken)
        {
            var proyecto = await _proyectoRepository.FindByIdAsync(request.ProyectoId);

            if (proyecto == null)
            {
                throw new Exception("Proyecto no encontrado");
            }
            proyecto.EnviarAObservacion();

            await _proyectoRepository.UpdateAsync(proyecto);

            await _unitOfWork.Commit();

            return proyecto.Id;
        }
    }
}
