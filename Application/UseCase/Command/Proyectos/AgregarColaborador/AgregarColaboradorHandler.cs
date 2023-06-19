using Application.UseCase.Command.Proyectos.CrearProyecto;
using Domain.Factory.Proyectos;
using Domain.Repository.Proyectos;
using Domain.Repository.Usuarios;
using MediatR;
using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var usuario = await _usuarioRepository.FindByIdAsync(request.UsuarioId);

            if (proyecto == null)
            {
                throw new Exception("Proyecto no encontrado");
            }

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            if (usuario.Id == proyecto.CreadorId)
            {
                throw new Exception("El usuario es el creador de este proyecto");
            }

            proyecto.AgregarColaborador(request.UsuarioId);

            await _proyectoRepository.UpdateAsync(proyecto);
            
            await _unitOfWork.Commit();
            
            return proyecto.Id;
        }
    }
}
