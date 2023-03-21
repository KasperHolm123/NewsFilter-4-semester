using CommunityToolkit.Mvvm.ComponentModel;
using NewsFilter_4_semester.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace NewsFilter_4_semester.Services
{
    public partial class FilterService : ObservableObject
    {
        #region Fields
        [ObservableProperty]
        private static ObservableCollection<Filter> _filters;

        [ObservableProperty]
        private static ObservableCollection<Article> _articles;

        public bool IsFilterOn { get; set; } = false;
        public bool IsWhiteListed { get; set; } = false;
        #endregion

        public FilterService()
        {
            Filters = new();
            Articles = new();
        }

        public ObservableCollection<Article> FilterArticles()
        {
            List<Article> list = new(Articles);
            foreach (var filter in Filters)
            {
                // ToUpper() to normalize the title/keyword.
                if (IsWhiteListed)
                    list.RemoveAll(x => !x.Title.ToUpper().Contains(filter.Keyword.ToUpper()));
                else
                    list.RemoveAll(x => x.Title.ToUpper().Contains(filter.Keyword.ToUpper()));
            }
            Articles = new(list);
            return Articles;
        }
    }
}
