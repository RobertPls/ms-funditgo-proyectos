 using Domain.ValueObjects;
using Shared.Core;

namespace Domain.Model.Proyectos
{
    public class Comentario : Entity<Guid>
    {
        public ComentarioValue Texto { get; private set; }
        public Guid UsuarioId { get; private set; }

        internal Comentario(Guid usuarioId, string texto)
        {
            if (usuarioId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El usuarioId es inválido.");
            }

            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
            Texto = texto;
        }
        private Comentario() { }
    }
}
