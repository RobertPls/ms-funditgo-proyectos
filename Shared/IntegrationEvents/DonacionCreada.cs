﻿using SharedKernel.Core;

namespace Shared.IntegrationEvents
{
    public record DonacionCreada : IntegrationEvent
    {
        public Guid DonacionId { get; set; }
    }
}