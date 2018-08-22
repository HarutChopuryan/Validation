using System.Collections.Generic;
using Validation.UI.ViewModels.Base;

namespace Validation.UI.ViewModels.Main
{
    public interface ICountryPickerViewModel
    {
        IAsyncCommand DoneCommand { get; }

        IAsyncCommand LoadCountriesCommand { get; }

        IEnumerable<string> Countries { get; }

        string SelectedCountry { get; set; }
    }
}