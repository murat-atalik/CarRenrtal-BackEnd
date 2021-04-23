using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator : AbstractValidator<CreditCard>
    {
        public PaymentValidator()
        {
            RuleFor(c=>c.CardNumber).NotEmpty();
            RuleFor(c => c.Cvv).NotEmpty();
            RuleFor(c => c.FullName).NotEmpty();
            RuleFor(c => c.ValidDate).NotEmpty();

        }
    }
}
