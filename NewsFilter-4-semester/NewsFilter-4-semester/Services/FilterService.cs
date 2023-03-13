using Java.Nio.Channels;
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
    public class FilterService : INotifyPropertyChanged
    {
        #region Interface implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Fields
        public static List<Filter> Filters { get; set; }
        private static List<Article> _articles;
        public List<Article> Articles
        {
            get => _articles;
            set
            {
                _articles = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsFilterOn { get; set; } = false;
        #endregion

        public FilterService()
        {
            Filters = new()
            {
                new Filter { Keywords = new List<string> { "Pernille" }}
            };
        }

        public List<Article> FilterList()
        {
            List<Article> list = new List<Article>(Articles);
            foreach (var filter in Filters)
            {
                foreach (var keyword in filter.Keywords)
                {
                    // ToUpper() to normalize the title/keyword.
                    list.RemoveAll(x => x.Title.ToUpper().Contains(keyword.ToUpper()));
                }
            }
            Articles = list;
            return Articles;
        }
    }
}
