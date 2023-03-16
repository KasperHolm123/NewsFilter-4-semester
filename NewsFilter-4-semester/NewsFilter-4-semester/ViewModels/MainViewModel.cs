using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsFilter_4_semester.Services;
using System.ComponentModel;
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
        private string _currentFeed;

        async partial void OnCurrentFeedChanged(string value) => await Refresh();

        public string[] FeedsArray { get; set; } = new string[3]
        {
            "Latest",
            "World",
            "Sport",
        };

        public Dictionary<string, string> FeedsDict { get; set; } = new Dictionary<string, string>()
        {
            { "Latest", "https://www.dr.dk/nyheder/service/feeds/senestenyt" },
            { "World", "https://www.dr.dk/nyheder/service/feeds/udland" },
            { "Sport", "https://www.dr.dk/nyheder/service/feeds/sporten" }
        };
        #endregion

        public MainViewModel(FilterService filterService)
        {
            FilterService = filterService;
            FilterService.Articles = Task.Run(() => XMLReaderService.GetArticles("https://www.dr.dk/nyheder/service/feeds/senestenyt")).Result;
            CurrentFeed = "Latest";
        }

        [RelayCommand]
        public async Task Refresh()
        {
            await ChangeShownArticles(FeedsDict[CurrentFeed]);
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
        }

        [RelayCommand]
        public static async Task ChangePage(string uri) => await Shell.Current.GoToAsync(uri);

        [RelayCommand]
        public static async Task ReadMore(string url) => await Browser.Default.OpenAsync(url);
    }
}
