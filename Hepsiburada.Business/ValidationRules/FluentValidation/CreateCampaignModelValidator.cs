using FluentValidation;
using Hepsiburada.Entities.Model;

namespace Hepsiburada.Business.ValidationRules.FluentValidation
{
    public class CreateCampaignModelValidator : AbstractValidator<CreateCampaignModel>
    {
        public CreateCampaignModelValidator()
        {
            RuleFor(u => u.ProductCode).NotEmpty().NotNull().Length(2, 50);
            RuleFor(u => u.Duration).GreaterThan(0);
            RuleFor(u => u.ManipulationLimit).GreaterThan(0);
            RuleFor(u => u.Name).NotEmpty().NotNull().Length(2, 50);
            RuleFor(u => u.TargetSalesCount).GreaterThan(0);   
        }
    }
}
