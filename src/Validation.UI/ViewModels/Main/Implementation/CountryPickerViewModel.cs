using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PropertyChanged;
using Validation.Core.Services;
using Validation.UI.ViewModels.Base;
using Validation.UI.ViewModels.Base.Implementation;

namespace Validation.UI.ViewModels.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class CountryPickerViewModel : BaseBindableObject, ICountryPickerViewModel
    {
        public CountryPickerViewModel(ICountriesService countriesService)
        {
            Countries = new List<string>();
            LoadCountriesCommand = new LoadCountriesCommand(this, countriesService);
            DoneCommand = new DoneCommand(this);
        }

        public IAsyncCommand DoneCommand { get; }

        public IAsyncCommand LoadCountriesCommand { get; }

        public IList<string> Countries { get; set; }

        public string SelectedCountry { get; set; }
    }
}