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

        [ObservableProperty]
        private bool _isBusy;

        async partial void OnCurrentFeedChanged(string value) => await RefreshAsync();

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
            FilterServiceObj = filterService;
            FilterServiceObj.Articles = Task.Run(() => XMLReaderService.GetArticles("https://www.dr.dk/nyheder/service/feeds/senestenyt")).Result;
            CurrentFeed = "Latest";
            IsBusy = false;
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
            if (IsBusy) return;
            try
            {
                IsBusy = true;

                var task = Task.Run(() => XMLReaderService.GetArticles(url));
                FilterServiceObj.Articles = await task;
                if (FilterServiceObj.IsFilterOn)
                {
                    FilterServiceObj.FilterArticles();
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Error while getting articles", "OK");
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
