using CommunityToolkit.Mvvm.Input;
using NewsFilter_4_semester.Models;
using NewsFilter_4_semester.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        public string FilterWord { get; set; }
        #endregion

        public SettingsPageViewModel(FilterService filterService)
        {
            FilterService = filterService;
        }

        [RelayCommand]
        public void AddFilter()
        {
            FilterService.Filters.Add(new Filter { Keyword = FilterWord });
        }
    }
}
