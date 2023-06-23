using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Command.Proyectos.AgregarDonacion
{
    public record AgregarDonacionCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
        public Guid UsuarioId { get; set; }
        public decimal Monto { get; set; }

    }
}
