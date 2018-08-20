using System.Threading;
using System.Threading.Tasks;

namespace Validation.Core.Services
{
    public interface IDataClient
    {
        Task<T> GetAsync<T>(string path, CancellationToken token = default(CancellationToken));
    }
}