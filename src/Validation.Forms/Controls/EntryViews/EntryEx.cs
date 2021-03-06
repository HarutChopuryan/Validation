﻿using Xamarin.Forms;

namespace Validation.Forms.Controls.EntryViews
{
    public class EntryEx : Entry
    {
        public static readonly BindableProperty HasErrorsProperty = BindableProperty.Create(nameof(HasErrors),
            typeof(bool),
            typeof(EntryEx),
            defaultValue: false);

        public bool HasErrors
        {
            get => (bool)GetValue(HasErrorsProperty);
            set => SetValue(HasErrorsProperty, value);
        }
    }
}
