using CommunityToolkit.Mvvm.Input;
using NewsFilter_4_semester.Models;
using NewsFilter_4_semester.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NewsFilter_4_semester.ViewModels
{
    public partial class SettingsPageViewModel : INotifyPropertyChanged
    {
        #region Interface implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Fields
        public FilterService FilterService { get; set; }

        private string _filterWord;
        public string FilterWord
        {
            get => _filterWord;
            set
            {
                _filterWord = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        public SettingsPageViewModel(FilterService filterService)
        {
            FilterService = filterService;
        }

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
