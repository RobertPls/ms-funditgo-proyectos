using Domain.Repository.Proyectos;
using Domain.Repository.Usuarios;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Proyectos.AgregarColaborador
{
    public class AgregarComentarioHandler : IRequestHandler<AgregarComentarioCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AgregarComentarioHandler(IProyectoRepository proyectoRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _usuarioRepository = usuarioRepository;

            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(AgregarComentarioCommand request, CancellationToken cancellationToken)
        {
            var proyecto = await _proyectoRepository.FindByIdAsync(request.ProyectoId);
            var usuario = await _usuarioRepository.FindByIdAsync(request.UsuarioId);

            if (proyecto == null)
            {
                throw new BussinessRuleValidationException("Proyecto no encontrado");
            }

            if (usuario == null)
            {
                throw new BussinessRuleValidationException("Usuario no encontrado");
            }

            proyecto.AgregarComentario(request.UsuarioId, request.Comentario);

            await _proyectoRepository.UpdateAsync(proyecto);

            await _unitOfWork.Commit();

            return proyecto.Id;
        }
    }
}
