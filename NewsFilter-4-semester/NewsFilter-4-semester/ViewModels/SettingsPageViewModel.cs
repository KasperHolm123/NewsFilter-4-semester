using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsFilter_4_semester.Models;
using NewsFilter_4_semester.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NewsFilter_4_semester.ViewModels
{
    public partial class SettingsPageViewModel : BaseViewModel
    {
        #region Fields
        #endregion

        public SettingsPageViewModel(FilterService filterService)
        {
            FilterService = filterService;
        }
    }
}
