using System;
using Validation.UI.ViewModels.Main;
using Xamarin.Forms.Xaml;

namespace Validation.Forms.Controls.EntryViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FailureView
    {
        public FailureView()
        {
            InitializeComponent();
        }

        private void OnTryAgainClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}