using Domain.Repository.Proyectos;
using Domain.Repository.Usuarios;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Usuarios.AgregarProyectoFavorito
{
    public class AgregarProyectoFavoritoHandler : IRequestHandler<AgregarProyectoFavoritoCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AgregarProyectoFavoritoHandler(IProyectoRepository proyectoRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _usuarioRepository = usuarioRepository;

            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(AgregarProyectoFavoritoCommand request, CancellationToken cancellationToken)
        {
            var proyecto = await _proyectoRepository.FindByIdAsync(request.ProyectoId);
            var usuario = await _usuarioRepository.FindByIdAsync(request.UsuarioId);

            var esCreadorOColaborador = proyecto.EsCreadorOColaborador(request.UsuarioId);

            if(esCreadorOColaborador)
            {
                throw new BussinessRuleValidationException("Formas parte de este proyecto");
            }

            if (proyecto == null)
            {
                throw new BussinessRuleValidationException("Proyecto no encontrado");
            }

            if (usuario == null)
            {
                throw new BussinessRuleValidationException("Usuario no encontrado");
            }

            usuario.AgregarFavorito(request.ProyectoId);

            await _usuarioRepository.UpdateAsync(usuario);

            await _unitOfWork.Commit();

            return usuario.Id;
        }
    }
}
