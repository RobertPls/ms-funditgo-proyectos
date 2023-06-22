using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Proyectos.Enum
{
    using System;

    public enum EstadoProyecto
    {
        Borrador = 1,
        Revision = 2,
        Aceptado = 3,
        Rechazado = 4,
        Finalizado = 5,
    }
}
