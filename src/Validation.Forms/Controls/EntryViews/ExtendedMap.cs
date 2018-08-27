using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Validation.Forms.Controls.EntryViews
{
    public class ExtendedMap : Map
    {
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
            foreach (var a in possibleAddresses)
                Debug.WriteLine(a);
        }
    }

    public class TapEventArgs : EventArgs
    {
        public Position Position { get; set; }
    }
}
