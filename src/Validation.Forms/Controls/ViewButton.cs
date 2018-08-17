using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Validation.Forms.Controls
{
    public class ViewButton : ContentView
    {
        public ViewButton()
        {
            BackgroundColor = Color.Transparent;
        }

        public event EventHandler<EventArgs> Clicked;

        public void InvokeClicked(object sender, EventArgs args)
        {
            Clicked?.Invoke(sender, args);
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command),
            typeof(ICommand),
            typeof(ViewButton),
            null);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty IsExecutableProperty = BindableProperty.Create(nameof(IsExecutable),
            typeof(bool),
            typeof(ViewButton),
            defaultValue: true);

        public bool IsExecutable
        {
            get => (bool)GetValue(IsExecutableProperty);
            set => SetValue(IsExecutableProperty, value);
        }
    }
}