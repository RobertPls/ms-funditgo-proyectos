using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Event.Proyectos
{
    public record DonacionCreada : DomainEvent
    {
        public Guid DonacionId { get; private set; }


        public DonacionCreada(Guid donacionId) : base(DateTime.Now)
        {
            DonacionId = donacionId;
        }
    }
}
