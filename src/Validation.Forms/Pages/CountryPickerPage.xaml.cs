using System;
using Validation.UI.ViewModels.Main;
using Xamarin.Forms.Xaml;

namespace Validation.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryPickerPage
    {
        private readonly ICountryPickerViewModel _countryPickerViewModel;

        //public EventHandler<string> CountrySelected;

        public CountryPickerPage(ICountryPickerViewModel countryPickerViewModel)
        {
            _countryPickerViewModel = countryPickerViewModel;
            InitializeComponent();
            BindingContext = _countryPickerViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _countryPickerViewModel.LoadCountriesCommand.Execute(null);
        }
    }
}