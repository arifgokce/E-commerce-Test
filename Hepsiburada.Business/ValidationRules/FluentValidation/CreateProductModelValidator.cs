using FluentValidation;
using Hepsiburada.Entities.Model;

namespace Hepsiburada.Business.ValidationRules.FluentValidation
{
    public class CreateProductModelValidator : AbstractValidator<CreateProductModel>
    {
        public CreateProductModelValidator()
        {
            RuleFor(u => u.ProductCode).NotEmpty().NotNull().Length(2, 50);
            RuleFor(u => u.ProductName).NotEmpty().NotNull().Length(2, 50);
            RuleFor(u => u.Price).GreaterThan(0);
        }
    }
}
