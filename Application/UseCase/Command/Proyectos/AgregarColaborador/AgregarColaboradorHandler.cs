using Domain.Model.Proyectos;
using Domain.Model.Usuarios;
using Domain.Repository.Proyectos;
using Domain.Repository.Usuarios;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCase.Command.Proyectos.AgregarColaborador
{
    public class AgregarColaboradorHandler : IRequestHandler<AgregarColaboradorCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AgregarColaboradorHandler(IProyectoRepository proyectoRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(AgregarColaboradorCommand request, CancellationToken cancellationToken)
        {
            var proyecto = await _proyectoRepository.FindByIdAsync(request.ProyectoId);
            var usuario = await _usuarioRepository.FindByUserNameAsync(request.UserNameUsuario);

            if (proyecto == null)
            {
                throw new BussinessRuleValidationException("Proyecto no encontrado");
            }

            if (usuario == null)
            {
                throw new BussinessRuleValidationException("Usuario no encontrado");
            }

            if (usuario.Id == proyecto.CreadorId)
            {
                throw new BussinessRuleValidationException("El usuario es el creador de este proyecto");
            }

            if (!proyecto.EsCreador(request.EjecutorId))
            {
                throw new BussinessRuleValidationException("No eres administrador de este proyecto");
            }

            proyecto.AgregarColaborador(usuario.Id);

            await _proyectoRepository.UpdateAsync(proyecto);
            
            await _unitOfWork.Commit();
            
            return proyecto.Id;
        }
    }
}
