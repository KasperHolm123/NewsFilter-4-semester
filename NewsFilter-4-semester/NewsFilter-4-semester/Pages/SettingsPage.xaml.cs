using NewsFilter_4_semester.ViewModels;

namespace NewsFilter_4_semester.Pages
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage(SettingsPageViewModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}

