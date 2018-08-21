using System;
using System.Collections.Generic;
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
            LoadCountriesCommand = new LoadCountriesCommand(this, countriesService);
            DoneCommand = new DoneCommand(this);
        }

        public IAsyncCommand DoneCommand { get; }

        public IAsyncCommand LoadCountriesCommand { get; }

        public IEnumerable<string> Countries { get; internal set; }

        public string SelectedCountry { get; set; }
    }
}