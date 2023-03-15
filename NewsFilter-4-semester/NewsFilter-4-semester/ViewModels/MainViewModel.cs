﻿using CommunityToolkit.Mvvm.Input;
using NewsFilter_4_semester.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NewsFilter_4_semester.ViewModels
{
    
    public partial class MainViewModel : INotifyPropertyChanged
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

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                NotifyPropertyChanged();
            }
        }

        public string CurrentFeed { get; set; }
        #endregion

        public MainViewModel(FilterService filterService)
        {
            FilterService = filterService;
            FilterService.Articles = Task.Run(() => XMLReaderService.GetArticles("https://www.dr.dk/nyheder/service/feeds/senestenyt")).Result;
            CurrentFeed = "https://www.dr.dk/nyheder/service/feeds/senestenyt";
        }

        [RelayCommand]
        public async Task Refresh()
        {
            await ChangeShownArticles(CurrentFeed);
            IsRefreshing = false;
        }

        [RelayCommand]
        public async Task ChangeShownArticles(string url)
        {
            var task = Task.Run(() => XMLReaderService.GetArticles(url));
            FilterService.Articles = await task;
            if (FilterService.IsFilterOn)
            {
                FilterService.FilterArticles();
            }
            CurrentFeed = url;
        }

        [RelayCommand]
        public static async Task ChangePage(string uri)
        {
            await Shell.Current.GoToAsync(uri);
        }

        [RelayCommand]
        public static async Task ReadMore(string url)
        {
            await Browser.Default.OpenAsync(url);
        }
    }
}
