using System;
using System.Collections.Generic;
using System.Windows.Input;
using PropertyChanged;
using Validation.Core.Models;
using Validation.Core.Services;
using Validation.UI.Validators;
using Validation.UI.ViewModels.Base;
using Validation.UI.ViewModels.Base.Implementation;

namespace Validation.UI.ViewModels.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel : BaseBindableObject, IMainViewModel
    {
        public MainViewModel(ICountriesService countriesService)
        {
            Validator = new MainValidator(this);
            LoadCountriesCommand = new LoadCountriesCommand(this, countriesService);
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<string> Gender { get; set; } = new List<string> {"Male", "Female"};

        public string PassportN { get; set; }
        
        public string Address { get; set; }

        public IList<string> Countries { get; set; }

        public bool CountriesButtonVisibility { get; set; }

        public IList<string> Cities { get; set; }

        public IAsyncCommand LoadCountriesCommand { get; set; }

        public IAsyncCommand LoadCitiesCommand { get; set; }

        public string ZipCode { get; set; }

        public IViewModelValidator Validator { get; }
    }
}
