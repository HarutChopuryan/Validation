using System.Collections.Generic;
using Validation.UI.ViewModels.Base;

namespace Validation.UI.ViewModels.Main
{
    public interface ICountryPickerViewModel
    {
        IAsyncCommand DoneCommand { get; }

        IAsyncCommand LoadCountriesCommand { get; }

        IList<string> Countries { get; set; }

        string SelectedCountry { get; set; }
    }
}