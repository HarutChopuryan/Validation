using Xamarin.Forms;

namespace Validation.Forms.Controls.EntryViews
{
    public class EntryView : BaseEntryView
    {
        public EntryEx TextEntry { get; private set; }

        public static readonly BindableProperty TextProperty = 
            BindableProperty.Create(nameof(Text),
                typeof(string),
                typeof(EntryView),
                defaultValue: null);
        
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty IsSpellCheckEnabledProperty = 
            BindableProperty.Create(nameof(IsSpellCheckEnabled),
                typeof(bool),
                typeof(EntryEx),
                defaultValue: false);

        public bool IsSpellCheckEnabled
        {
            get => (bool)GetValue(IsSpellCheckEnabledProperty);
            set => SetValue(IsSpellCheckEnabledProperty, value);
        }

        protected override void Initialize()
        {
            TextEntry = new EntryEx
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            ControlContainer.Content = TextEntry;
            TextEntry.SetBinding(Entry.TextProperty, new Binding(nameof(Text), BindingMode.TwoWay, source: this));
            TextEntry.SetBinding(InputView.IsSpellCheckEnabledProperty, new Binding(nameof(IsSpellCheckEnabled), BindingMode.TwoWay, source: this));
        }

        protected override void UpdateErrors(bool hasErrors)
        {
            TextEntry.HasErrors = hasErrors;
        }

        protected override void UpdateTitle(string title, bool showPlaceholder)
        {
            TextEntry.Placeholder = showPlaceholder ? title : null;
        }
    }
}