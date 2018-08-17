using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Validation.UI.ViewModels.Base.Implementation
{
    public class BaseBindableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}