using System;
using System.Collections.Generic;
using System.Linq;
using Validation.UI.ViewModels.Main;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Validation.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private static int _firstTime;

        private readonly Geocoder _geoCoder;

        private readonly Map _map;
        private readonly IMainViewModel _viewModel;

        public MapPage(IMainViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            _geoCoder = new Geocoder();
            _map = new Map(MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            MainContent.Content = _map;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_firstTime == 0)
            {
                _map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(40.1772, 44.50349),
                    Distance.FromMiles(0.7)));
                _firstTime++;
            }
            else
            {
                _map.MoveToRegion(MapSpan.FromCenterAndRadius(_viewModel.Coordinates, Distance.FromKilometers(0.1)));
            }
        }

        private async void OnMapDoneClicked(object sender, EventArgs e)
        {
            var possibleAddresses = await _geoCoder.GetAddressesForPositionAsync(_map.VisibleRegion.Center);
            var adressList = possibleAddresses as string[] ?? possibleAddresses.ToArray();
            var location = GetLocation(adressList);
            _viewModel.Coordinates = _map.VisibleRegion.Center;
            _viewModel.Address = location.Address;
            _viewModel.City = location.City;
            _viewModel.Country = location.Country;
            _viewModel.ZipCode = location.ZipCode;
            await Navigation.PopAsync();
        }

        private Location GetLocation(IEnumerable<string> adressList)
        {
            Location location = new Location();
            try
            {
                var addressArr = adressList.FirstOrDefault()?.Split(',').Select(str => str.TrimStart()).ToList();
                location.Address = addressArr[0];
                location.City = addressArr[1].Split(' ')[0];
                location.Country = addressArr[2];
                location.ZipCode = addressArr[1].Split(' ')[1];
            }
            catch (Exception e)
            {
                return new Location
                {
                    Address = string.IsNullOrWhiteSpace(location.Address) ? " " : location.Address,
                    City = string.IsNullOrWhiteSpace(location.City) ? " " : location.City,
                    Country = string.IsNullOrWhiteSpace(location.Country) ? " " : location.Country,
                    ZipCode = string.IsNullOrWhiteSpace(location.ZipCode) ? " " : location.ZipCode
                };
            }
            return location;
        }
    }

    public class Location
    {
        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }
    }
}