using FluentValidation;
using Validation.UI.ViewModels.Base.Implementation;
using Validation.UI.ViewModels.Main.Implementation;

namespace Validation.UI.Validators
{
    internal class MainValidator : BaseViewModelValidator<MainViewModel>
    {
        public MainValidator(MainViewModel mainViewModel) : base(mainViewModel)
        {
            RuleFor(viewModel => viewModel.FirstName).Length(1,5).WithMessage("sdfsdf");
        }
    }
}