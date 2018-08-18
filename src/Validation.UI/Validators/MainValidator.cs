using FluentValidation;
using Validation.UI.ViewModels.Base.Implementation;
using Validation.UI.ViewModels.Main.Implementation;

namespace Validation.UI.Validators
{
    internal class MainValidator : BaseViewModelValidator<MainViewModel>
    {
        public MainValidator(MainViewModel mainViewModel) : base(mainViewModel)
        {
            RuleFor(viewModel => viewModel.FirstName).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Required").Matches(@"^[a-zA-Z]+$").WithMessage("Only Letters");
            RuleFor(viewModel => viewModel.LastName).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Required").Matches(@"^[a-zA-Z]+$").WithMessage("Only Letters");
            RuleFor(viewModel => viewModel.PassportN).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Required").Matches(@"[A-Z]{2}\d{7}")
                .WithMessage("First 2 uppercase letters then 7 numbers");
            RuleFor(viewModel => viewModel.Address).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Required").MaximumLength(150)
                .WithMessage("Max length 150");
            RuleFor(viewModel => viewModel.ZipCode).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Required").Matches(@"^[a-zA-Z0-9]+$")
                .WithMessage("Only letters and numbers").MaximumLength(10).WithMessage("Max length 10");

        }
    }
}