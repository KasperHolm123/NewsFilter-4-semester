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
        private List<Article> _articles;
        public List<Article> Articles
        {
            get => _articles;
            set
            {
                _articles = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        public MainViewModel()
        {
        }

        [RelayCommand]
        public async Task ChangeShownArticles(string type)
        {
            switch (type)
            {
                case "Trending":
                    var task = Task.Run(() => XMLReaderService.GetArticles("https://www.dr.dk/nyheder/service/feeds/senestenyt"));
                    Articles = await task;
                    break;
                case "World":
                    //Articles = XMLReaderService.GetArticles("https://www.dr.dk/nyheder/service/feeds/udland");
                    break;
                case "Technology":
                    //Articles = XMLReader.Technology();
                    break;
                default:
                    break;
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
