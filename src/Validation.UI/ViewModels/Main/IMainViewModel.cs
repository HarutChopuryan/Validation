using System.Collections.Generic;
using System.Windows.Input;
using Validation.Core.Models;
using Validation.UI.ViewModels.Base;

namespace Validation.UI.ViewModels.Main
{
    public interface IMainViewModel : IValidateableViewModel
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        IList<string> Gender { get; set; }

        string PassportN { get; set; }

        string Address { get; set; }

        Countries Countries { get; set; }

        IAsyncCommand LoadCountriesCommand { get; set; }

        IList<string> Cities { get; set; }

        IAsyncCommand LoadCitiesCommand { get; set; }

        string ZipCode { get; set; }
    }
}