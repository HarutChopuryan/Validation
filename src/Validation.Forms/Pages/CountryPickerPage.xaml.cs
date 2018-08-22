using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Validation.UI.ViewModels.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Validation.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryPickerPage
    {
        private readonly ICountryPickerViewModel _viewModel;

        public EventHandler<string> CountrySelected;

        public CountryPickerPage(ICountryPickerViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            BindingContext = _viewModel;
            NavigationPage.SetHasBackButton(this, false);
        }

        public string SelectedCountry
        {
            get => _viewModel.SelectedCountry;
            set => _viewModel.SelectedCountry = value;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadCountriesCommand.Execute(null);
        }

        private async void OnDoneClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            if (_viewModel.SelectedCountry != null)
                CountrySelected.Invoke(this, listView.SelectedItem.ToString());
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            List<string> newItemsSource = new List<string>();
            if(_viewModel.Countries != null && searchBar.Text != "" && searchBar.Text != null)
            {
                var searchResult = (listView.ItemsSource as List<string>).Where(country => country.Contains(searchBar.Text));
                listView.ItemsSource = null;
                foreach (var result in searchResult)
                {
                    newItemsSource.Add(result);
                }
                if (newItemsSource.Count != 0)
                {
                    _viewModel.Countries = newItemsSource;
                }
            }
            else
            {
                _viewModel.LoadCountriesCommand.Execute(null);
            }
        }
    }
}