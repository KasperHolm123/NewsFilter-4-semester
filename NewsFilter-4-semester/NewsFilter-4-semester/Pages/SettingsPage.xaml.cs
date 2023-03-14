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
            MainStackLayout.BackgroundColor = Color.FromHex("#1C1C1E");
            foreach (var child in MainStackLayout.Children)
            {
                if (child is Label label)
                {
                    label.TextColor = Color.FromHex("#FFFFFF");
                }
            }

            
        }
        else
        {
            // Apply light theme
            MainStackLayout.BackgroundColor = Color.FromHex("#FFFFFF");
            foreach (var child in MainStackLayout.Children)
            {
                if (child is Label label)
                {
                    label.TextColor = Color.FromHex("#000000");
                }
            }
        }
    }

}

//Forsøg på at binde det til ContentPage
//public static class ThemeHelper
//{
//    public static void ApplyTheme(Page page)
//    {
//        var theme = App.Current.RequestedTheme;

//        if (theme == AppTheme.Dark)
//        {
//            // Apply dark theme
//            page.BackgroundColor = Color.FromHex("#1C1C1E");

//            label.TextColor = Color.FromHex("#FFFFFF");


//        }
//        else
//        {
//            // Apply light theme
//            MainStackLayout.BackgroundColor = Color.FromHex("#FFFFFF");
//            foreach (var child in MainStackLayout.Children)
//            {
//                if (child is Label label)
//                {
//                    label.TextColor = Color.FromHex("#000000");
//                }
//            }
//        }
//    }
//}