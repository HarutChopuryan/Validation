using System;
using System.Collections.Generic;
using System.Windows.Input;
using PropertyChanged;
using Validation.Core.Models;
using Validation.Core.Services;
using Validation.UI.Validators;
using Validation.UI.ViewModels.Base;
using Validation.UI.ViewModels.Base.Implementation;
using Xamarin.Forms.Maps;

namespace Validation.UI.ViewModels.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel : BaseBindableObject, IMainViewModel
    {
        public MainViewModel(ICountriesService countriesService)
        {
            Validator = new MainValidator(this);
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> Gender { get; set; } = new List<string> {"Male", "Female"};

        public string PassportN { get; set; }
        
        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public Position Coordinates { get; set; }

        public IViewModelValidator Validator { get; }
    }
}