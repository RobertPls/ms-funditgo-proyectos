using Domain.Factory.Proyectos;
using Domain.Repository.Proyectos;
using Domain.Repository.Usuarios;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCase.Command.Proyectos.CrearProyecto
{
    public class CrearProyectoHandler : IRequestHandler<CrearProyectoCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProyectoFactory _proyectoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearProyectoHandler(IProyectoRepository proyectoRepository, IUsuarioRepository usuarioRepository, IProyectoFactory proyectoFactory, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _usuarioRepository = usuarioRepository;
            _proyectoFactory = proyectoFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CrearProyectoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.FindByIdAsync(request.CreadorId);

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            var proyecto = _proyectoFactory.Crear(
                request.CreadorId, 
                request.TipoproyectoId, 
                request.Titulo, 
                request.Descripcion, 
                request.Historia, 
                request.CompromisoAmbiental,
                request.DonacionEsperada, 
                request.DonacionMinima
                );

            await _proyectoRepository.CreateAsync(proyecto);
            await _unitOfWork.Commit();
            return proyecto.Id;
        }
    }
}
