using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Event.Proyectos
{
    public record ColaboradorEliminado : DomainEvent
    {
        public Guid ColaboradorId { get; private set; }

        public ColaboradorEliminado(Guid colaboradorId) : base(DateTime.Now)
        {
            ColaboradorId = colaboradorId;
        }
    }
}
