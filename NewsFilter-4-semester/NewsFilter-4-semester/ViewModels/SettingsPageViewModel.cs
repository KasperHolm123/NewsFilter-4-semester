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
        [ObservableProperty]
        private string _filterWord;
        #endregion

        public SettingsPageViewModel(FilterService filterService) => FilterService = filterService;

        [RelayCommand]
        public void AddFilter()
        {
            if (FilterWord != null && FilterWord != string.Empty && FilterWord != "")
            {
                // ToUpper() to normalize values
                FilterService.Filters.Add(new Filter { Keyword = FilterWord.ToUpper() });
            }
            // clear input field
            FilterWord = "";
        }

        [RelayCommand]
        public void RemoveFilter(Filter filter)
        {
            // ToUpper() to normalize values
            FilterService.Filters.RemoveAll(x => x.Keyword.ToUpper() == filter.Keyword.ToUpper());
        }
    }
}
