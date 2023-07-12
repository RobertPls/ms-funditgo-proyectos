using Application.UseCase.Command.Proyectos.EliminarColaborador;
using Domain.Repository.Proyectos;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCase.Command.Proyectos.AgregarColaborador
{
    public class EliminarColaboradorHandler : IRequestHandler<EliminarColaboradorCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarColaboradorHandler(IProyectoRepository proyectoRepository, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarColaboradorCommand request, CancellationToken cancellationToken)
        {
            var proyecto = await _proyectoRepository.FindByIdAsync(request.ProyectoId);

            if (proyecto == null)
            {
                throw new BussinessRuleValidationException("Proyecto no encontrado");
            }

            if (!proyecto.EsCreador(request.EjecutorId))
            {
                throw new BussinessRuleValidationException("No eres administrador de este proyecto");
            }

            proyecto.EliminarColaborador(request.ColaboradorId);

            await _proyectoRepository.UpdateAsync(proyecto);

            await _unitOfWork.Commit();

            return proyecto.Id;
        }
    }
}
