﻿using SharedKernel.Core;

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
