using System;
using System.Diagnostics;
using System.Linq;
using Validation.Core.DI;
using Validation.Core.Extensions;
using Validation.Forms.Pages;
using Validation.UI;
using Validation.UI.ViewModels.Main;
using Validation.UI.ViewModels.Main.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Validation.Forms.Controls.EntryViews
{
    public class ExtendedMap : Map
    {
        public static readonly BindableProperty AddressTextProperty =
            BindableProperty.Create(nameof(AddressText),
                typeof(string),
                typeof(EntryView),
                defaultValue: null);

        public string AddressText
        {
            get => (string)GetValue(AddressTextProperty);
            set => SetValue(AddressTextProperty, value);
        }

        public static readonly BindableProperty CountryTextProperty =
            BindableProperty.Create(nameof(CountryText),
                typeof(string),
                typeof(EntryView),
                defaultValue: null);

        public string CountryText
        {
            get => (string)GetValue(CountryTextProperty);
            set => SetValue(CountryTextProperty, value);
        }

        public static readonly BindableProperty CityTextProperty =
            BindableProperty.Create(nameof(CityText),
                typeof(string),
                typeof(EntryView),
                defaultValue: null);

        public string CityText
        {
            get => (string)GetValue(CityTextProperty);
            set => SetValue(CityTextProperty, value);
        }

        public static readonly BindableProperty ZipTextProperty =
            BindableProperty.Create(nameof(ZipText),
                typeof(string),
                typeof(EntryView),
                defaultValue: null);

        public string ZipText
        {
            get => (string)GetValue(ZipTextProperty);
            set => SetValue(ZipTextProperty, value);
        }

        public Position Coordinates;

        private Geocoder _geoCoder;

        public event EventHandler<TapEventArgs> Tap;

        public ExtendedMap()
        {
            _geoCoder = new Geocoder();
        }

        public ExtendedMap(MapSpan region) : base(region)
        {

        }

        public void OnTap(Position coordinate)
        {
            OnTap(new TapEventArgs { Position = coordinate });
        }

        protected async virtual void OnTap(TapEventArgs e)
        {
            var handler = Tap;
            if (handler != null)
                handler(this, e);
            Coordinates = e.Position;
            var possibleAddresses = await _geoCoder.GetAddressesForPositionAsync(Coordinates);
            var addressArr = possibleAddresses.FirstOrDefault().Split(',').Select(str => str.TrimStart()).ToList();
            AddressText = addressArr[0];
            CountryText = addressArr[2];
            CityText = addressArr[1].Split(' ')[0];
            ZipText = addressArr[1].Split(' ')[1];
            Debug.Write($"{AddressText}    {CountryText}    {CityText}    {ZipText}");
        }
    }

    public class TapEventArgs : EventArgs
    {
        public Position Position { get; set; }
    }
}