using System;
using WestCoastEducation_App.Interfaces;
using WestCoastEducation_App.Enums;
using WestCoastEducation_App.ViewModels;

namespace WestCoastEducation_App.Factories;

public class PageViewFactory : IPageViewFactory
{
    private readonly Func<PageViewEnum, ViewModelBase> _pageFactory;
    public PageViewFactory(Func<PageViewEnum, ViewModelBase> pageFactory)
    {
        _pageFactory = pageFactory;
    }

    public ViewModelBase LoadPageViewModel(PageViewEnum page)
    {
        return _pageFactory.Invoke(page);
    }

}
