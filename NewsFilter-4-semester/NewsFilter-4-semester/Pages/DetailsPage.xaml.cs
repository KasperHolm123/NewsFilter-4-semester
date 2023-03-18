using NewsFilter_4_semester.ViewModels;

namespace NewsFilter_4_semester.Pages;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsPageViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}