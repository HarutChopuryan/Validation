using System.Threading;
using System.Threading.Tasks;

namespace Validation.UI.ViewModels.Base
{
    public interface IAsyncCommand : IBindableCommand
    {
        bool IsBusy { get; }
        
        string FailureMessage { get; }
        
        bool IsSuccessful { get; }
        
        Task ExecuteAsync(object param = null, CancellationToken token = default(CancellationToken));
    }
}