using System.Diagnostics;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Validation.UI.ViewModels.Main.Implementation;

namespace Validation.UI.ViewModels.Base.Implementation
{
    public class DoneCommand : AsyncCommand
    {
        private readonly CountryPickerViewModel _viewModel;

        public DoneCommand(CountryPickerViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter = null, CancellationToken token = default(CancellationToken))
        {
            Debug.Write("asdff");
            return true;
        }
    }
}
