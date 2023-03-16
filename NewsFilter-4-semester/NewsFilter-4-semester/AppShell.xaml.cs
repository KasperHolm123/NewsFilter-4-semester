using NewsFilter_4_semester.Pages;

namespace NewsFilter_4_semester;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(FilterPage), typeof(FilterPage));
    }
}
