using System.ComponentModel;
using System.Windows.Input;

namespace Validation.UI.ViewModels.Base
{
    public interface IBindableCommand : ICommand, INotifyPropertyChanged
    {
        bool IsExecutable { get; }
    }
}