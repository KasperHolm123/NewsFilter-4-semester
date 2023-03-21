using NewsFilter_4_semester.ViewModels;

namespace NewsFilter_4_semester.Pages;

public partial class FilterPage : ContentPage
{
	public FilterPage(FilterPageViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}