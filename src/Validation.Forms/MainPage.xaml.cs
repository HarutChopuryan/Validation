using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.UI.ViewModels.Main;
using Xamarin.Forms;

namespace Validation.Forms
{
	public partial class MainPage : ContentPage
	{
	    private readonly IMainViewModel _viewModel;
        public MainPage(IMainViewModel viewModel)
		{
		    _viewModel = viewModel;
            InitializeComponent();
		    BindingContext = _viewModel;
		}
	}
}
