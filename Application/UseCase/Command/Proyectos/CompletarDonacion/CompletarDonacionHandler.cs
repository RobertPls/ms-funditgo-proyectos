using Application.UseCase.Command.Proyectos.AgregarDonacion;
using Domain.Repository.Proyectos;
using Domain.Repository.Usuarios;
using MediatR;
using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Command.Proyectos.CompletarDonacion
{
    public class CompletarDonacionHandler : IRequestHandler<CompletarDonacionCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompletarDonacionHandler(IProyectoRepository proyectoRepository, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;

            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CompletarDonacionCommand request, CancellationToken cancellationToken)
        {
            var proyecto = await _proyectoRepository.FindByIdAsync(request.ProyectoId);

            if (proyecto == null)
            {
                throw new Exception("Proyecto no encontrado");
            }

            proyecto.CompletarDonacion(request.DonacionId);

            await _proyectoRepository.UpdateAsync(proyecto);

            await _unitOfWork.Commit();

            return proyecto.Id;
        }
    }
}
