﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grace.DependencyInjection.Lifestyle;
using Validation.Core.DI;
using Validation.Core.Services;
using Validation.Core.Services.Implementation;
using Validation.Forms.Pages;
using Validation.UI.ViewModels.Main;
using Validation.UI.ViewModels.Base.Implementation;
using Validation.UI.ViewModels.Main.Implementation;
using Xamarin.Forms;

namespace Validation.Forms.Pages
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

	    private void OnLocateClicked(object sender, EventArgs e)
	    {
	        var mapPage = ServiceLocator.Instance.Locate<MapPage>(LifestyleType.Singleton);
	        Navigation.PushAsync(mapPage);
	    }
	}
}