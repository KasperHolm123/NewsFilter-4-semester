using NewsFilter_4_semester.Pages;

namespace NewsFilter_4_semester;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void SettingsBtn_Click(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new SettingsPage());
    }
}

