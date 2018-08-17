using Xamarin.Forms;

namespace Validation.Forms.Controls
{
    public class StackListView : LimitedItemsView
    {
        public StackLayout Root { get; }

        public StackListView()
        {
            Root = new StackLayout
            {
                Padding = 0,
                Spacing = ItemSpacing,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Children.Insert(0, Root);
        }

        public static readonly BindableProperty ItemSpacingProperty = 
            BindableProperty.Create(nameof(ItemSpacing),
                typeof(double),
                typeof(StackListView),
                0d,
                propertyChanged: OnItemSpacingChanged);

        public double ItemSpacing
        {
            get => (double)GetValue(ItemSpacingProperty);
            set => SetValue(ItemSpacingProperty, value);
        }

        private static void OnItemSpacingChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var stack = (StackListView)bindable;
            stack.Root.Spacing = stack.ItemSpacing;
        }

        protected override void AddView(View view, int index = -1)
        {
            index = index >= 0 && index <= Root.Children.Count ? index : Root.Children.Count;
            Root.Children.Insert(index, view);
        }

        protected override void RemoveView(int index)
        {
            if (index >= 0 && index < Root.Children.Count)
            {
                Root.Children.RemoveAt(index);
            }
        }

        protected override void Clear()
        {
            base.Clear();
            Root.Children.Clear();
            Children.Insert(0, Root);
        }
    }
}