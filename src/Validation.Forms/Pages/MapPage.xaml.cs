using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.UI.ViewModels.Main;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Validation.Forms.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
	    private readonly IMainViewModel _viewModel;

		public MapPage (IMainViewModel viewModel)
		{
		    _viewModel = viewModel;
			InitializeComponent ();
		    NavigationPage.SetHasBackButton(this, false);
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(_viewModel.Coordinates.Latitude, _viewModel.Coordinates.Longitude), Distance.FromMiles(1)));
        }

	    private async void OnMapDoneClicked(object sender, EventArgs e)
	    {
	        _viewModel.Coordinates = map.Coordinates;
	        _viewModel.Address = map.AddressText;
	        _viewModel.City = map.CityText;
	        _viewModel.Country = map.CountryText;
	        _viewModel.ZipCode = map.ZipText;
	        await Navigation.PopAsync();
	    }
	}
}