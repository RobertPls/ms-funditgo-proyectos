using Application.UseCase.Command.Proyectos.AgregarDonacion;
using Domain.Factory.TiposProyectos;
using Domain.Repository.Proyectos;
using Domain.Repository.TiposTipoProyectos;
using Domain.Repository.Usuarios;
using MediatR;
using Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Command.TiposProyectos.CrearTipoProyecto
{
    public class CrearTipoProyectoHandler : IRequestHandler<CrearTipoProyectoCommand, Guid>
    {
        private readonly ITipoProyectoRepository _tipoProyectoRepository;
        private readonly ITipoProyectoFactory _tipoProyectoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearTipoProyectoHandler(ITipoProyectoRepository tipoProyectoRepository, IUnitOfWork unitOfWort)
        {
            _tipoProyectoRepository = tipoProyectoRepository;

            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CrearTipoProyectoCommand request, CancellationToken cancellationToken)
        {
            var tipoProyecto = _tipoProyectoFactory.Crear(request.Id, request.Nombre);

            await _tipoProyectoRepository.CreateAsync(tipoProyecto);
            await _unitOfWork.Commit();
            return tipoProyecto.Id;
        }
    }
}
