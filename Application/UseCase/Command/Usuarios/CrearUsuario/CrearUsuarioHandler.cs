using Domain.Factory.Proyectos;
using Domain.Repository.Usuarios;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCase.Command.Usuarios.CrearUsuario
{
    public class CrearUsuarioHandler : IRequestHandler<CrearUsuarioCommand, Guid>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioFactory _usuarioFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearUsuarioHandler(IUsuarioRepository usuarioRepository, IUsuarioFactory usuarioFactory, IUnitOfWork unitOfWort)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioFactory = usuarioFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = _usuarioFactory.Crear(request.Id, request.NombreCompleto, request.UserName);
            await _usuarioRepository.CreateAsync(usuario);
            await _unitOfWork.Commit();
            return usuario.Id;
        }
    }
}
