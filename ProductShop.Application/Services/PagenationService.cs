using AutoMapper;
using ProductShop.Application.InputModels;
using ProductShop.Application.Services.Interface;
using ProductShop.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Application.Services;
public class PagenationService<T, S> : IPagenationService<T, S> where T : class
{
    private readonly IMapper _mapper;

    public PagenationService(IMapper mapper)
    {
        _mapper = mapper;
    }
    public PagenationVM<T> GetPagenation(List<S> source, PagenationInputModel pagenationInput)
    {
        var currentpage = pagenationInput.PageNumber;
        
        throw new NotImplementedException();
    }
}
