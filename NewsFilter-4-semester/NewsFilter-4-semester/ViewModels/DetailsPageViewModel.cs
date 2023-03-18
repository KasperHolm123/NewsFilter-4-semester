using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsFilter_4_semester.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFilter_4_semester.ViewModels
{
    public partial class DetailsPageViewModel : BaseViewModel
    {

        [ObservableProperty]
        private DetailedArticle _articleObj;

        public DetailsPageViewModel(DetailedArticle article) => ArticleObj = article;

        [RelayCommand]
        public static async Task OpenArticle(string url) => await Browser.Default.OpenAsync(url);
    }
}
