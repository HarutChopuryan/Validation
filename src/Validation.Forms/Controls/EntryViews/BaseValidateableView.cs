using System.Collections;
using System.ComponentModel;
using Validation.UI.ViewModels.Base;
using Xamarin.Forms;

namespace Validation.Forms.Controls.EntryViews
{
    public class 
        BaseValidateableView : ContentView
    {
        private IViewModelValidator _validationContext;

        //Validator
        public static readonly BindableProperty ValidatorProperty = 
            BindableProperty.Create(nameof(Validator),
                typeof(IViewModelValidator),
                typeof(BaseEntryView),
                defaultValue: null);

        public IViewModelValidator Validator
        {
            get => (IViewModelValidator)GetValue(ValidatorProperty);
            set => SetValue(ValidatorProperty, value);
        }

        //ValidationIds
        public static readonly BindableProperty ValidationIdProperty = 
            BindableProperty.Create(nameof(ValidationId),
                typeof(string),
                typeof(BaseEntryView));

        public string ValidationId
        {
            get => (string)GetValue(ValidationIdProperty);
            set => SetValue(ValidationIdProperty, value);
        }

        private IList _errors;

        public IList Errors
        {
            get => _errors;
            private set
            {
                if (!Equals(_errors, value))
                {
                    _errors = value;
                    OnPropertyChanged(nameof(Errors));
                }
            }
        }

        protected override void OnBindingContextChanged()
        {
            if (_validationContext != null)
            {
                _validationContext.ErrorsChanged -= OnErrorsChanged;
            }

            _validationContext = Validator ?? (BindingContext as IValidateableViewModel)?.Validator;
            if (_validationContext != null)
            {
                _validationContext.ErrorsChanged += OnErrorsChanged;
            }

            UpdateErrorsInternal();
            base.OnBindingContextChanged();
        }

        private void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            if (ValidationId == null) return;
            if (string.IsNullOrEmpty(e.PropertyName) || ValidationId.Contains(e.PropertyName))
            {
                UpdateErrorsInternal();
            }
        }

        protected virtual void UpdateErrors(bool hasErrors)
        {
        }

        private void UpdateErrorsInternal()
        {
            if (_validationContext != null)
            {
                Errors = _validationContext.GetAllErrors(ValidationId);
                var hasErrors = Errors != null && Errors.Count > 0;
                UpdateErrors(hasErrors);
            }
        }
    }
}
