using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Command.TiposProyectos.CrearTipoProyecto
{
    public record CrearTipoProyectoCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public CrearTipoProyectoCommand(Guid id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }

}
