using NewsFilter_4_semester.Pages;
using NewsFilter_4_semester.Services;
using NewsFilter_4_semester.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFilter_4_semester
{
    public static class ServicesHandler
    {

        public static MauiAppBuilder RegisterCustomServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<FilterService>();
            return builder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<SettingsPageViewModel>();
            builder.Services.AddSingleton<FilterPageViewModel>();
            builder.Services.AddTransient<DetailsPageViewModel>();
            return builder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<SettingsPage>();
            builder.Services.AddSingleton<FilterPage>();
            builder.Services.AddTransient<DetailsPage>();
            return builder;
        }
    }
}
