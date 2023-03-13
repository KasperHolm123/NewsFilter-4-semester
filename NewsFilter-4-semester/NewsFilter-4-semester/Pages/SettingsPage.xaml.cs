using NewsFilter_4_semester.Resources.Themes;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.ApplicationModel;

namespace NewsFilter_4_semester.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private void ThemeSwitch_Toggled(object sender, ToggledEventArgs e)
    {

        //Switch themeSwitch = (Switch)sender;
        //if (themeSwitch.IsToggled)
        //{
        //    Application.Current.Resources = new ResourceDictionaryDark();
        //}
        //else
        //{
        //    Application.Current.Resources = new ResourceDictionaryLight();
        //}

        if (e.Value)
        {
            App.Current.UserAppTheme = AppTheme.Dark;
        }
        else
        {
            App.Current.UserAppTheme = AppTheme.Light;
        }

        UpdateTheme();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        App.Current.RequestedThemeChanged += OnAppThemeChanged;
        UpdateTheme();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        App.Current.RequestedThemeChanged -= OnAppThemeChanged;
        UpdateTheme();
    }

    //private void OnAppThemeChanged(object sender, AppThemeChangedEventArgs e)
    //{
    //    if (e.RequestedTheme == AppTheme.Dark)
    //    {
    //        App.Current.UserAppTheme = AppTheme.Dark;
    //    }
    //    else
    //    {
    //        App.Current.UserAppTheme = AppTheme.Light;
    //    }
    //}

    private void OnAppThemeChanged(object sender, AppThemeChangedEventArgs e)
    {
        UpdateTheme();
    }

    private void UpdateTheme()
    {
        var theme = App.Current.RequestedTheme;

        if (theme == AppTheme.Dark)
        {
            // Apply dark theme
            MainStackLayout.BackgroundColor = Color.FromArgb("#1C1C1E");
            foreach (Label label in MainStackLayout.Children)
            {
                label.TextColor = Color.FromArgb("#FFFFFF");
            }
            //Application.Current.Resources = new ResourceDictionaryDark();
        }
        else
        {
            // Apply light theme
            MainStackLayout.BackgroundColor = Color.FromArgb("#FFFFFF");
            foreach (Label label in MainStackLayout.Children)
            {
                label.TextColor = Color.FromArgb("#000000");
            }
            //Application.Current.Resources = new ResourceDictionaryLight();
        }
    }
}