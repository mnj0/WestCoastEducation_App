using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WestCoastEducation_App.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    public partial string PageTitle { get; set; } = "";
}
