﻿using Android.Content;
using Android.Gms.Maps;
using Validation.Droid;
using Validation.Forms.Controls.EntryViews;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedMap), typeof(ExtendedMapRenderer))]

namespace Validation.Droid
{
    public class ExtendedMapRenderer : MapRenderer, IOnMapReadyCallback
    {
        private GoogleMap _map;

        public ExtendedMapRenderer(Context context) : base(context)
        {
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;
            if (_map != null)
                _map.MapClick += googleMap_MapClick;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            if (_map != null)
                _map.MapClick -= googleMap_MapClick;
            base.OnElementChanged(e);
            if (Control != null)
                Control.GetMapAsync(this);
        }

        private void googleMap_MapClick(object sender, GoogleMap.MapClickEventArgs e)
        {
            ((ExtendedMap) Element).OnTap(new Position(e.Point.Latitude, e.Point.Longitude));
        }
    }
}