using System.ComponentModel;

namespace Validation.UI.ViewModels.Base
{
    public interface IValidateableViewModel : INotifyPropertyChanged
    {
        IViewModelValidator Validator { get; }
    }
}