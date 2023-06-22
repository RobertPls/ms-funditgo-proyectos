using Domain.ValueObjects;
using SharedKernel.Core;

namespace Domain.Model.Proyectos
{
    public class Donacion : Entity<Guid>
    {
        public DonacionValue Monto { get; private set; }
        public Guid UsuarioId { get; private set; }

        internal Donacion(Guid usuarioId, decimal monto)
        {
            if (usuarioId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El usuarioId es inválido.");
            }

            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
            Monto = monto;
        }
        private Donacion() { }
    }
}
