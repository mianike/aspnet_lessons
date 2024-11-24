using FluentValidation;
using ArsenalFansWebApp.Models;

namespace ArsenalFansWebApp.Validation
{
    public class FeedbackViewModelValidator : AbstractValidator<FeedbackViewModel>
    {
        public FeedbackViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                .Matches("^[A-Za-z ]+$").WithMessage("Name should only contain letters and spaces")
                .MaximumLength(100).WithMessage("The name length must not exceed 100 characters");

            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(150).WithMessage("Email must not exceed 150 characters");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required")
                .Matches("^[A-Za-z0-9 ]+$").WithMessage("Subject should only contain letters, numbers, and spaces")
                .MaximumLength(100).WithMessage("The subject length must not exceed 100 characters");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Feedback message is required")
                .MinimumLength(10).WithMessage("Feedback message should be at least 10 characters long")
                .MaximumLength(2000).WithMessage("The feedback length must not exceed 2000 characters");
        }
    }
}