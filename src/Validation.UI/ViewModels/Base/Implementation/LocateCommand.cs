﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Validation.Core.Models;
using Validation.UI.ViewModels.Main;
using Xamarin.Forms.Maps;

namespace Validation.UI.ViewModels.Base.Implementation
{
    public class LocateCommand : AsyncCommand
    {
        private readonly IMainViewModel _viewModel;

        private readonly Geocoder _geoCoder;

        public LocateCommand(IMainViewModel viewModel)
        {
            _viewModel = viewModel;
            _geoCoder = new Geocoder();
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter = null, CancellationToken token = default(CancellationToken))
        {
            var possibleAddresses = await _geoCoder.GetAddressesForPositionAsync(_viewModel.Map.VisibleRegion.Center);
            var adressList = possibleAddresses as string[] ?? possibleAddresses.ToArray();
            var location = GetLocation(adressList);
            _viewModel.Coordinates = _viewModel.Map.VisibleRegion.Center;
            _viewModel.Address = location.Address;
            _viewModel.City = location.City;
            _viewModel.Country = location.Country;
            _viewModel.ZipCode = location.ZipCode;
            return true;
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
}