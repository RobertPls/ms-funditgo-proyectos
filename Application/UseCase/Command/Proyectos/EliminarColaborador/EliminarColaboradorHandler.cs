using Application.UseCase.Command.Proyectos.CrearProyecto;
using Application.UseCase.Command.Proyectos.EliminarColaborador;
using Domain.Factory.Proyectos;
using Domain.Repository.Proyectos;
using MediatR;
using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            var colaborador = proyecto.Colaboradores.FirstOrDefault(x => x.Id == request.ColaboradorId);

            if (proyecto == null)
            {
                throw new Exception("Proyecto no encontrado");
            }

            if (colaborador == null)
            {
                throw new Exception("Colaborador no encontrado");
            }

            proyecto.EliminarColaborador(colaborador);

            await _proyectoRepository.UpdateAsync(proyecto);

            await _unitOfWork.Commit();

            return proyecto.Id;
        }
    }
}
