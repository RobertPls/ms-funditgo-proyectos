using Application.UseCase.Command.Proyectos.CrearProyecto;
using Application.UseCase.Command.Proyectos.EliminarColaborador;
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
    public class EliminarComentarioHandker : IRequestHandler<EliminarComentarioCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarComentarioHandker(IProyectoRepository proyectoRepository, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarComentarioCommand request, CancellationToken cancellationToken)
        {
            var proyecto = await _proyectoRepository.FindByIdAsync(request.ProyectoId);

            var comentario = proyecto.Comentarios.FirstOrDefault(x => x.Id == request.ComentarioId);

            if (proyecto == null)
            {
                throw new Exception("Proyecto no encontrado");
            }

            if (comentario == null)
            {
                throw new Exception("Comentario no encontrado");
            }

            proyecto.EliminarComentario(comentario);

            await _proyectoRepository.UpdateAsync(proyecto);

            await _unitOfWork.Commit();

            return proyecto.Id;
        }
    }
}
