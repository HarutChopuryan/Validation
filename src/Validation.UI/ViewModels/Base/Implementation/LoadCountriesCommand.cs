using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validation.Core.Services;
using Validation.UI.ViewModels.Main.Implementation;

namespace Validation.UI.ViewModels.Base.Implementation
{
    internal class LoadCountriesCommand : AsyncCommand
    {
        private readonly MainViewModel _mainViewModel;
        private readonly ICountriesService _countriesService;

        public LoadCountriesCommand(MainViewModel mainViewModel, ICountriesService countriesService)
        {
            _mainViewModel = mainViewModel;
            _mainViewModel.Countries = new List<string>();
            _countriesService = countriesService;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter = null, CancellationToken token = default(CancellationToken))
        {
            try
            {
                if (_mainViewModel.Countries.Count == 0)
                {
                    var countries = await _countriesService.GetCountriesAsync();
                    foreach (var country in countries)
                        _mainViewModel.Countries.Add(country.CountryNames);
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
