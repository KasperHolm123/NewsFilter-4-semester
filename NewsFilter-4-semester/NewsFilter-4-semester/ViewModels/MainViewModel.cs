using NewsFilter_4_semester.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
﻿using CommunityToolkit.Mvvm.Input;
using NewsFilter_4_semester.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFilter_4_semester.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NewsFilter_4_semester.ViewModels
{
    
    public partial class MainViewModel
    {
        #region Fields
        public FilterService FilterService { get; set; }
        #endregion

        public MainViewModel(FilterService filterService)
        {
            FilterService = filterService;
        }

        [RelayCommand]
        public async Task ChangeShownArticles(string url)
        {
            var task = Task.Run(() => XMLReaderService.GetArticles(url));
            FilterService.Articles = await task;
            if (FilterService.IsFilterOn)
            {
                FilterService.FilterList();
            }
        }

        [RelayCommand]
        public async Task ChangePage(string uri)
        {
            await Shell.Current.GoToAsync(uri);
        }

        [RelayCommand]
        public async Task ReadMore(string url)
        {
            await Browser.Default.OpenAsync(url);
        }
    }
}
