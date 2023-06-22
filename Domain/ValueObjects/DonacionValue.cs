using SharedKernel.Core;
using SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public record DonacionValue : ValueObject
    {
        public decimal Value { get; }

        public DonacionValue(decimal value)
        {
            CheckRule(new NotNullRule(value));
            if (value < 1)
            {
                throw new BussinessRuleValidationException("No puede ser menor a 1");
            }
            Value = value;
        }

        public static implicit operator decimal(DonacionValue value)
        {
            return value.Value;
        }

        public static implicit operator DonacionValue(decimal value)
        {
            return new DonacionValue(value);
        }
    }
}
