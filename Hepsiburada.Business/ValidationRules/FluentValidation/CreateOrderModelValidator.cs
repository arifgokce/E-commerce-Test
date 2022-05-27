using FluentValidation;
using Hepsiburada.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Business.ValidationRules.FluentValidation
{
    public class CreateOrderModelValidator : AbstractValidator<CreateOrderModel>
    {
        public CreateOrderModelValidator()
        {
            RuleFor(u => u.ProductCode).NotEmpty().NotNull().Length(2, 50);
            RuleFor(u => u.Quantity).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
