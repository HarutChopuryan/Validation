using System;
using System.Collections.Generic;
using PropertyChanged;
using Validation.UI.Validators;
using Validation.UI.ViewModels.Base;
using Validation.UI.ViewModels.Base.Implementation;

namespace Validation.UI.ViewModels.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel : BaseBindableObject, IMainViewModel
    {
        public MainViewModel()
        {
            Validator = new MainValidator(this);
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PassportN { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public IList<string> Cities { get; set; }

        public string ZipCode { get; set; }

        public IViewModelValidator Validator { get; }
    }
}
