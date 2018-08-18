using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Validation.Forms.Controls.EntryViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DatePickerView
	{
		public DatePickerView ()
		{
			InitializeComponent ();
		}

	    public static readonly BindableProperty TitleProperty =
	        BindableProperty.Create(nameof(Title),
	            typeof(string),
	            typeof(PickerView),
	            null);

	    public string Title
	    {
	        get => (string)GetValue(TitleProperty);
	        set => SetValue(TitleProperty, value);
	    }

	    public static readonly BindableProperty TitleWidthProperty =
	        BindableProperty.Create(nameof(TitleWidth),
	            typeof(double),
	            typeof(PickerView),
	            defaultValue: 120d);

	    public double TitleWidth
	    {
	        get => (double)GetValue(TitleWidthProperty);
	        set => SetValue(TitleWidthProperty, value);
	    }
    }
}