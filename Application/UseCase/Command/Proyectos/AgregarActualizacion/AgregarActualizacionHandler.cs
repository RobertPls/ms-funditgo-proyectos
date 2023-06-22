using Application.UseCase.Command.Proyectos.AgregarColaborador;
using Domain.Repository.Proyectos;
using Domain.Repository.Usuarios;
using MediatR;
using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Command.Proyectos.AgregarActualizacion
{
    public class AgregarActualizacionHandler : IRequestHandler<AgregarActualizacionCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AgregarActualizacionHandler(IProyectoRepository proyectoRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _usuarioRepository = usuarioRepository;

            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(AgregarActualizacionCommand request, CancellationToken cancellationToken)
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

            proyecto.AgregarActualizacion(request.UsuarioId, request.Descripcion);

            await _proyectoRepository.UpdateAsync(proyecto);

            await _unitOfWork.Commit();

            return proyecto.Id;
        }
    }
}
