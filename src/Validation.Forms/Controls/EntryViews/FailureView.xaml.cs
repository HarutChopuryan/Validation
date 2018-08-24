using System;
using System.Windows.Input;
using Validation.UI.ViewModels.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Validation.Forms.Controls.EntryViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FailureView
    {
        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create(nameof(Message),
                typeof(string),
                typeof(FailureView),
                null);

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public static readonly BindableProperty TryAgainCommandProperty =
            BindableProperty.Create(nameof(TryAgainCommand),
                typeof(ICommand),
                typeof(FailureView),
                null);

        public ICommand TryAgainCommand
        {
            get => (ICommand)GetValue(TryAgainCommandProperty);
            set => SetValue(TryAgainCommandProperty, value);
        }

        public FailureView()
        {
            InitializeComponent();
        }
    }
}