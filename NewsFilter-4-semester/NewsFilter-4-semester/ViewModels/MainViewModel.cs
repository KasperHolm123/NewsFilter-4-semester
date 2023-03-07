using CommunityToolkit.Mvvm.Input;
using NewsFilter_4_semester.Models;
using NewsFilter_4_semester.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFilter_4_semester.ViewModels
{
    public partial class MainViewModel
    {
        public ObservableCollection<Article> Articles { get; set; }


        [RelayCommand]
        public async Task ChangeShownArticles(string type)
        {
            switch (type)
            {
                //TODO: Add case for each type of news (sports, technology etc.)
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
