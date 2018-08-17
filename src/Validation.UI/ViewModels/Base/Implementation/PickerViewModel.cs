using System.Collections.Generic;
using PropertyChanged;

namespace Validation.UI.ViewModels.Base.Implementation
{
    [AddINotifyPropertyChangedInterface]
    class PickerViewModel : BaseBindableObject, IPickerViewModel
    {
        public List<string> PickerItems { get; set; }

        public IViewModelValidator Validator { get; }
    }
}
