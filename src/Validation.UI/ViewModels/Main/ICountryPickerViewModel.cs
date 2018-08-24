using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;
using Validation.UI.ViewModels.Base;

namespace Validation.UI.ViewModels.Main
{
    public interface ICountryPickerViewModel
    {
        IAsyncCommand DoneCommand { get; }

        IAsyncCommand LoadCountriesCommand { get; }

        IAsyncCommand SearchCommand { get; set; }

        IEnumerable<string> Countries { get; }

        IEnumerable<string> BaseItems { get; }

        string SelectedCountry { get; set; }

        string SearchNotFound { get; set; }

        string SearchText { get; set; }

        int Count { get; set; }
    }
}