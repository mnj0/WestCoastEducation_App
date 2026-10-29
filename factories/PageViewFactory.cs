using System;
using WestCoastEducation_App.Interfaces;
using WestCoastEducation_App.Enums;
using WestCoastEducation_App.ViewModels;

namespace WestCoastEducation_App.Factories;

public class PageViewFactory : IPageViewFactory
{
    public ViewModelBase LoadPageViewModel(PageViewEnum page)
    {
        return page switch
        {
            PageViewEnum.Home => new HomeViewModel(),
            _ => throw new InvalidOperationException("Det fanns inte det du ville ha"),
        };
    }

    /*public ViewModelBase LoadPageViewModel(PageViewEnum page, string itemNumber)
    {
        return page switch
        {
            PageViewsEnum.EditProduct => new EditProductViewModel(new ProductServices(), itemNumber),
            _ => throw new InvalidOperationException("Det fanns inte det du ville ha")
        };
    }*/
}
