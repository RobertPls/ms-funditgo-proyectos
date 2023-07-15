using Domain.ValueObjects;
using Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Proyectos
{
    public class Actualizacion : Entity<Guid>
    {
        public DateTime Fecha { get; private set; }
        public DescripcionValue Descripcion { get; private set; }
        public Guid UsuarioId { get; private set; }

        internal Actualizacion(Guid usuarioId, string descripcion)
        {
            if (usuarioId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El usuarioId es inválido.");
            }

            Id = Guid.NewGuid();
            Fecha = DateTime.Now;
            UsuarioId = usuarioId;
            Descripcion = descripcion;
        }
        private Actualizacion() { }
    }
}
