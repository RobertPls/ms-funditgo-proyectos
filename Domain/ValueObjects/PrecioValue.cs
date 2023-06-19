using SharedKernel.Core;
using SharedKernel.Rules;

namespace Domain.ValueObjects
{
    public record PrecioValue : ValueObject
    {
        public decimal Value { get; }

        public PrecioValue(decimal value)
        {
            CheckRule(new NotNullRule(value));
            if (value < 0)
            {
                throw new BussinessRuleValidationException("No puede ser menor a 0");
            }
            Value = value;
        }

        public static implicit operator decimal(PrecioValue value)
        {
            return value.Value;
        }

        public static implicit operator PrecioValue(decimal value)
        {
            return new PrecioValue(value);
        }
    }
}
