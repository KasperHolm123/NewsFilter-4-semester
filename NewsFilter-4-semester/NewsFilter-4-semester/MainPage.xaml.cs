using NewsFilter_4_semester.ViewModels;

namespace NewsFilter_4_semester
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}
