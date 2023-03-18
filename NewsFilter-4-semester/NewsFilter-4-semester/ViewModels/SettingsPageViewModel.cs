using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsFilter_4_semester.Models;
using NewsFilter_4_semester.Services;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NewsFilter_4_semester.ViewModels
{
    public partial class SettingsPageViewModel : BaseViewModel
    {
        #region Fields
        [ObservableProperty]
        private bool _isDarkTheme;
        partial void OnIsDarkThemeChanged(bool value) => ChangeTheme();
        #endregion

        public SettingsPageViewModel(FilterService filterService)
        {
            FilterServiceObj = filterService;
            if (Application.Current.RequestedTheme == AppTheme.Light)
                IsDarkTheme = false;
            else
                IsDarkTheme = true;
        }

        [RelayCommand]
        public void ChangeTheme()
        {
            if (IsDarkTheme)
                Application.Current.UserAppTheme = AppTheme.Dark;
            else
                Application.Current.UserAppTheme = AppTheme.Light;
        }
    }
}
