using Domain.ValueObjects;
using Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.TiposProyectos
{
    public class TipoProyecto : AggregateRoot<Guid>
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }

        public TipoProyecto(Guid id, string nombre)
        {
            if (id == Guid.Empty)
            {
                throw new BussinessRuleValidationException("Necesita un id");
            }

            Id = Guid.NewGuid();
            Nombre = nombre;
        }
        private TipoProyecto() { }
    }
}
