using SharedKernel.Core;

namespace Domain.Model.Proyectos
{
    public class Colaborador : Entity<Guid>
    {
        public Guid UsuarioId { get; private set; }

        internal Colaborador(Guid usuarioId)
        {
            if (usuarioId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El usuarioId es inválido.");
            }

            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
        }
        private Colaborador() { }
    }
}
