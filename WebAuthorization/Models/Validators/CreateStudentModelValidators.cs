using FluentValidation;

namespace WebAuthorization.Models.Validators
{
    public class CreateStudentModelValidators : AbstractValidator<CreateStudentModel>
    {
        public CreateStudentModelValidators()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Enter Name");

            this.RuleFor(x => x.Name)
                .Must(x => x.ToUpper().First() == x.First())
                .WithMessage("First letter must be capital");

            this.RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("Minimum chars - 3");
        }
    }
}
