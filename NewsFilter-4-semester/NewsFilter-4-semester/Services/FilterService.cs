using CommunityToolkit.Mvvm.ComponentModel;
using NewsFilter_4_semester.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NewsFilter_4_semester.Services
{
    public partial class FilterService : ObservableObject
    {
        #region Fields
        [ObservableProperty]
        private static List<Filter> _filters;

        [ObservableProperty]
        private static List<Article> _articles;

        public bool IsFilterOn { get; set; } = false;
        public bool IsWhiteListed { get; set; } = false;
        #endregion

        public FilterService()
        {
            Filters = new();
        }

        public List<Article> FilterArticles()
        {
            List<Article> list = new(Articles);
            foreach (var filter in Filters)
            {
                // ToUpper() to normalize the title/keyword.
                if (IsWhiteListed)
                {
                    list.RemoveAll(x => !x.Title.ToUpper().Contains(filter.Keyword.ToUpper()));
                }
                else
                {
                    list.RemoveAll(x => x.Title.ToUpper().Contains(filter.Keyword.ToUpper()));
                }
            }
            Articles = list;
            return Articles;
        }
    }
}
