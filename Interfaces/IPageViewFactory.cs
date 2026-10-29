using WestCoastEducation_App.Enums;
using WestCoastEducation_App.ViewModels;

namespace WestCoastEducation_App.Interfaces;

public interface IPageViewFactory
{
    ViewModelBase LoadPageViewModel(PageViewEnum page);
}
