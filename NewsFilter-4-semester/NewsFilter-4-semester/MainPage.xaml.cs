using Microsoft.Maui.Controls;
using NewsFilter_4_semester.Models;
using NewsFilter_4_semester.ViewModels;
using System.Collections.ObjectModel;

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
