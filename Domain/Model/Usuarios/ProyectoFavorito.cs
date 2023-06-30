using SharedKernel.Core;

namespace Domain.Model.Usuarios
{
    public class ProyectoFavorito : Entity<Guid>
    {
        public Guid ProyectoId { get; private set; }

        internal ProyectoFavorito(Guid proyectoId)
        {
            if (proyectoId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El proyectoId es inválido.");
            }

            Id = Guid.NewGuid();
            ProyectoId = proyectoId;
        }
        private ProyectoFavorito() { }
    }
}
