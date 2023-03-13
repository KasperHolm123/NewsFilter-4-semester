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
    public partial class SettingsPageViewModel
    {
        #region Fields
        public FilterService FilterService { get; set; }
        #endregion


        public SettingsPageViewModel(FilterService filterService)
        {
            FilterService = filterService;
        }

        [RelayCommand]
        public void AddFilter()
        {
            FilterService.Filters.Add(new Filter 
            {
                Keywords = new List<string>
                {
                    "Pernille"
                }
            });
        }
    }
}
