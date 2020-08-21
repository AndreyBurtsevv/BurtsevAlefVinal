using DataService;
using FluentValidation;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlefVinalServices.Validation
{
    public class ValueValidator : AbstractValidator<Value>
    {
        public ValueValidator()
        {
            RuleFor(c => c.Name).NotNull().WithMessage("Error in field {PropertyName}");

            RuleFor(c => c.Description).NotNull().Must(c => c.All(Char.IsDigit)).LessThan("1234").WithMessage("Error in field {PropertyValue}");
        }
    }
}
