using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Validation.Core.Services;
using Validation.UI.ViewModels.Main.Implementation;

namespace Validation.UI.ViewModels.Base.Implementation
{
    public class LoadCountriesCommand : AsyncCommand
    {
        private readonly ICountriesService _countriesService;
        private readonly CountryPickerViewModel _viewModel;

        public LoadCountriesCommand(CountryPickerViewModel viewModel, ICountriesService countriesService)
        {
            _viewModel = viewModel;
            _countriesService = countriesService;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter = null, CancellationToken token = default(CancellationToken))
        {
            if (_viewModel.Countries == null || _viewModel.Countries.Count() == 0)
            {
                var countries = await _countriesService.GetCountriesAsync(token);
                _viewModel.Countries = countries.Select(country => country.Name).ToList();
            }
            return true;
        }
    }
}