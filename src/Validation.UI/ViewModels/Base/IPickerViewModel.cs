using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Validation.UI.ViewModels.Base
{
    interface IPickerViewModel : INotifyPropertyChanged, IValidateableViewModel
    {
        List<string> PickerItems { get; set; }
    }
}