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

namespace NewsFilter_4_semester.ViewModels
{
    
    public partial class MainViewModel
    {
        //public ObservableCollection<Article.Channel> Articles { get; set; }
        public List<Article> Articles { get; set; }

        public MainViewModel()
        {
            Articles = XMLReaderService.Trending();
        }

        
        [RelayCommand]
        public async Task ChangeShownArticles(string type)
        {
            switch (type)
            {
                case "Trending":
                    //Articles = XMLReaderService.Trending();
                    break;
                case "World":
                    //Articles = XMLReader.World();
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
    }
}
