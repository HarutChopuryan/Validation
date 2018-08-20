using System.Collections.Generic;
using Validation.UI.ViewModels.Base;

namespace Validation.UI.ViewModels.Main
{
    public interface ICountryPickerViewModel
    {
        string SelectedCountry { get; set; }

        IAsyncCommand DoneCommand { get; }

        IAsyncCommand LoadCountriesCommand { get; }

        IEnumerable<string> Countries { get; }
    }
}