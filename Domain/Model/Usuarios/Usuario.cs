using Domain.Model.Proyectos;
using Domain.ValueObjects;
using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Usuarios
{
    public class Usuario : AggregateRoot<Guid>
    {
        public NombrePersonaValue NombreCompleto { get; private set; }

        private Usuario() { }

        internal Usuario(Guid id, string nombreCompleto)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
        }
    }
}
