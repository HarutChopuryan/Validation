using System.Collections.Generic;
using Validation.UI.ViewModels.Base;
using Xamarin.Forms.Maps;

namespace Validation.UI.ViewModels.Main
{
    public interface IMainViewModel : IValidateableViewModel
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        IEnumerable<string> Gender { get; set; }

        string PassportN { get; set; }

        string Address { get; set; }

        string ZipCode { get; set; }

        string Country { get; set; }

        string City { get; set; }

        Position Coordinates { get; set; }
    }
}