using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsFilter_4_semester.Models;
using NewsFilter_4_semester.Pages;
using NewsFilter_4_semester.Services;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;

namespace NewsFilter_4_semester.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        #region Fields

        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _currentFeed;
        async partial void OnCurrentFeedChanged(string value) => await RefreshAsync();

        
        public static Dictionary<string, string> FeedsDict { get; set; } = new Dictionary<string, string>()
        {
            { "Latest", "https://www.dr.dk/nyheder/service/feeds/senestenyt" },
            { "Denmark", "https://www.dr.dk/nyheder/service/feeds/indland" },
            { "Finance", "https://www.dr.dk/nyheder/service/feeds/penge" },
            { "Politics", "https://www.dr.dk/nyheder/service/feeds/politik" },
            { "Knowledge", "https://www.dr.dk/nyheder/service/feeds/viden" },
            { "Culture", "https://www.dr.dk/nyheder/service/feeds/kultur" },
            { "Music", "https://www.dr.dk/nyheder/service/feeds/musik" },
            { "My Life", "https://www.dr.dk/nyheder/service/feeds/mitliv" },
            { "Food", "https://www.dr.dk/nyheder/service/feeds/mad" },
            { "Weather", "https://www.dr.dk/nyheder/service/feeds/vejret" },
            { "Regional", "https://www.dr.dk/nyheder/service/feeds/regionale" },
            { "World", "https://www.dr.dk/nyheder/service/feeds/udland" },
            { "Sport", "https://www.dr.dk/nyheder/service/feeds/sporten" },
        };
        
        public List<string> RssFeeds { get; } = FeedsDict.Keys.ToList();
        #endregion

        public MainViewModel(FilterService filterService)
        {
            FilterServiceObj = filterService;
            FilterServiceObj.Articles = Task.Run(() => XMLReaderService.GetArticles("https://www.dr.dk/nyheder/service/feeds/senestenyt")).Result;
            CurrentFeed = "Latest";
            IsBusy = false;
        }

        [RelayCommand]
        public void ChangeCurrentFeed(string text)
        {
            CurrentFeed = text;
        }

        [RelayCommand]
        public async Task RefreshAsync()
        {
            await ChangeShownArticlesAsync(FeedsDict[CurrentFeed]);
            IsRefreshing = false;
        }

        [RelayCommand]
        public async Task ChangeShownArticlesAsync(string url)
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                var task = Task.Run(() => XMLReaderService.GetArticles(url));
                FilterServiceObj.Articles = await task;
                if (FilterServiceObj.IsFilterOn)
                    FilterServiceObj.FilterArticles();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public static async Task ChangePage(string uri) => await Shell.Current.GoToAsync(uri);

        [RelayCommand]
        public static async Task ReadMore(string url) => await Browser.Default.OpenAsync(url);
    }
}
