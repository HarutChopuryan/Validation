using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Validation.Core.Models;

namespace Validation.Core.Services
{
    public interface IDataClient
    {
        Task<List<Countries>> GetAsync(string path, CancellationToken token = default(CancellationToken));
    }
}