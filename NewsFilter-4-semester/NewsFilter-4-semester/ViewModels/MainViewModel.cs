﻿using NewsFilter_4_semester.Models;
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
        public Article.Rss Articles { get; set; }

        public MainViewModel()
        {
            Articles = XMLReaderService.Trending();
            //Articles.Add(new Article.Channel { Title = "title1", Description = "description1" });
            //Articles.Add(new Article.Channel { Title = "title2", Description = "description2" });
            //Articles.Add(new Article.Channel { Title = "title3", Description = "description3" });
            //Articles.Add(new Article.Channel { Title = "title4", Description = "description4" });
            //Articles.Add(new Article.Channel { Title = "title5", Description = "description5" });
            //Articles.Add(new Article.Channel { Title = "title6", Description = "description6" });
            //Articles.Add(new Article.Channel { Title = "title7", Description = "description7" });
            //Articles.Add(new Article.Channel { Title = "title8", Description = "description8" });
            //Articles.Add(new Article.Channel { Title = "title9", Description = "description9" });
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
