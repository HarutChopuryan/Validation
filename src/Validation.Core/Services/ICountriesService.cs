using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Validation.Core.Models;

namespace Validation.Core.Services
{
    public interface ICountriesService
    {
        Task<List<Country>> GetCountriesAsync(CancellationToken token = default(CancellationToken));
    }
}