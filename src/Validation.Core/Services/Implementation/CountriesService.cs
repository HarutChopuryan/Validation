using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Validation.Core.Models;

namespace Validation.Core.Services.Implementation
{
    public class CountriesService : ICountriesService
    {
        private readonly IDataClient _dataClient;

        public CountriesService(IDataClient dataClient)
        {
            _dataClient = dataClient;
        }

        public Task<List<Countries>> GetCountriesAsync(CancellationToken token = default(CancellationToken))
        {
            return _dataClient.GetAsync($"/all", token);
        }
    }
}