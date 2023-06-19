using SharedKernel.Core;
using SharedKernel.Rules;

namespace Domain.ValueObjects
{
    public record NombrePersonaValue : ValueObject
    {
        public string Nombre { get; init; }

        public NombrePersonaValue(string nombre)
        {
            CheckRule(new StringNotNullOrEmptyRule(nombre));
            if (nombre.Length > 50)
            {
                throw new BussinessRuleValidationException("Nombre no puede tener mas de 50 caracteres");
            }
            Nombre = nombre;
        }

        public static implicit operator string(NombrePersonaValue value)
        {
            return value.Nombre;
        }

        public static implicit operator NombrePersonaValue(string nombre)
        {
            return new NombrePersonaValue(nombre);
        }
    }
}
