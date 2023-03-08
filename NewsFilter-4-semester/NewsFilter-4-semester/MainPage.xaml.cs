using Microsoft.Maui.Controls;
using NewsFilter_4_semester.Models;
using System.Collections.ObjectModel;

namespace NewsFilter_4_semester
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Article.Channel> Articles { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Articles = new ObservableCollection<Article.Channel>();
            Articles.Add(new Article.Channel { Title = "title1", Description = "description1" });
            Articles.Add(new Article.Channel { Title = "title2", Description = "description2" });
            Articles.Add(new Article.Channel { Title = "title3", Description = "description3" });
            Articles.Add(new Article.Channel { Title = "title4", Description = "description4" });
            Articles.Add(new Article.Channel { Title = "title5", Description = "description5" });
            Articles.Add(new Article.Channel { Title = "title6", Description = "description6" });
            Articles.Add(new Article.Channel { Title = "title7", Description = "description7" });
            Articles.Add(new Article.Channel { Title = "title8", Description = "description8" });
            Articles.Add(new Article.Channel { Title = "title9", Description = "description9" });

            BindingContext = this;
        }
    }
}
