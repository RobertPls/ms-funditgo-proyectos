using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Command.Proyectos.AgregarColaborador
{
    public record AgregarColaboradorCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
        public Guid UsuarioId { get; set; }

    }
}
