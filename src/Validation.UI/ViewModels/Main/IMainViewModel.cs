using System.Collections.Generic;
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

        string Country { get; set; }

        string City { get; set; }

        IList<string> Cities { get; set; }

        string ZipCode { get; set; }
    }
}