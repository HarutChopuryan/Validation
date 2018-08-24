using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Windows.Input;
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
            SearchCommand = new SearchCommand(this);
        }

        public IAsyncCommand DoneCommand { get; }

        public IAsyncCommand LoadCountriesCommand { get; }

        public IAsyncCommand SearchCommand { get; set; }

        public IEnumerable<string> Countries { get; internal set; }

        public IEnumerable<string> BaseItems { get; internal set; }

        public string SelectedCountry { get; set; }

        public string SearchText { get; set; }

        public string SearchNotFound { get; set; }

        public int Count { get; set; }
    }
}