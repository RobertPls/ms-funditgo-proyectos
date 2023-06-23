using Domain.Repository.Proyectos;
using Domain.Repository.Usuarios;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCase.Command.Proyectos.AgregarDonacion
{
    public class AgregarDonacionHandler : IRequestHandler<AgregarDonacionCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AgregarDonacionHandler(IProyectoRepository proyectoRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _usuarioRepository = usuarioRepository;

            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(AgregarDonacionCommand request, CancellationToken cancellationToken)
        {
            var proyecto = await _proyectoRepository.FindByIdAsync(request.ProyectoId);
            var usuario = await _usuarioRepository.FindByIdAsync(request.UsuarioId);

            if (proyecto == null)
            {
                throw new Exception("Proyecto no encontrado");
            }

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            proyecto.AgregarDonacion(request.UsuarioId, request.Monto);

            await _proyectoRepository.UpdateAsync(proyecto);

            await _unitOfWork.Commit();

            return proyecto.Id;
        }
    }
}
