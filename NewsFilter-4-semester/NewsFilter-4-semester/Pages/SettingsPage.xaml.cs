using Android.OS.Strictmode;
using Java.Lang;
using NewsFilter_4_semester.Resources.Themes;

namespace NewsFilter_4_semester.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();

        void ThemeSwitch_Toggled(object sender, EventArgs e)
        {
            Switch themeSwitch = (Switch)sender;
            if (themeSwitch.IsToggled)
            {
                Application.Current.Resources = new ResourceDictionaryDark();
            }
            else
            {
                Application.Current.Resources = new ResourceDictionaryLight();
            }
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Set the switch's initial value based on the current application theme
        if (Application.Current.Resources is ResourceDictionaryDark)
        {
            ThemeSwitch.IsToggled = true;
        }
        else
        {
            ThemeSwitch.IsToggled = false;
        }
    }
}