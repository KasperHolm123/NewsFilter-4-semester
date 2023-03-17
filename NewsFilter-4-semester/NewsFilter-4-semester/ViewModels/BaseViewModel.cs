using CommunityToolkit.Mvvm.ComponentModel;
using NewsFilter_4_semester.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFilter_4_semester.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private FilterService _filterServiceObj;
    }
}
