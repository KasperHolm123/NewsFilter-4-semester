using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsFilter_4_semester.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFilter_4_semester.ViewModels
{
    [QueryProperty(nameof(Article), "Article")]
    public partial class DetailsPageViewModel : BaseViewModel
    {

        [ObservableProperty]
        private DetailedArticle _article;

        [RelayCommand]
        public static async Task OpenArticle(string url) => await Browser.Default.OpenAsync(url);
    }
}
