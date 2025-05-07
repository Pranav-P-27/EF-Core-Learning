using ProductShop.Application.InputModels;
using ProductShop.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Application.Services.Interface;
public interface IPagenationService<T,S> where T : class
{
    PagenationVM<T> GetPagenation(List<S> source, PagenationInputModel pagenationInput);
}
