using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsFilter_4_semester.Models;
using NewsFilter_4_semester.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFilter_4_semester.ViewModels
{
    public partial class FilterPageViewModel : BaseViewModel
    {
        #region Fields
        [ObservableProperty]
        private string _filterWord;
        #endregion


        public FilterPageViewModel(FilterService filterService) => FilterServiceObj = filterService;

        [RelayCommand]
        public void AddFilter()
        {
            if (FilterWord != null && FilterWord != string.Empty && FilterWord != "")
            {
                // ToUpper() to normalize values
                FilterServiceObj.Filters.Add(new Filter { Keyword = FilterWord.ToUpper() });
            }
            // clear input field
            FilterWord = "";
        }

        [RelayCommand]
        public void DeleteFilter(Filter filter) => FilterServiceObj.Filters.Remove(filter);
    }
}
