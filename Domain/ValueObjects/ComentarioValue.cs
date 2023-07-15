using Shared.Core;
using Shared.Rules;

namespace Domain.ValueObjects
{
    public record ComentarioValue : ValueObject
    {
        public string Comentario { get; init; }

        public ComentarioValue(string comentario)
        {
            CheckRule(new StringNotNullOrEmptyRule(comentario));
            if (comentario.Length > 100)
            {
                throw new BussinessRuleValidationException("Comentario no puede tener mas de 100 caracteres");
            }
            Comentario = comentario;
        }

        public static implicit operator string(ComentarioValue value)
        {
            return value.Comentario;
        }

        public static implicit operator ComentarioValue(string comentario)
        {
            return new ComentarioValue(comentario);
        }
    }
}
