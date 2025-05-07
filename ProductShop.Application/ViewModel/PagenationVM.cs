using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Application.ViewModel
{
    public class PagenationVM<T>
    {
        public int Currentpage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int TotalNoOfRecords { get; set; }

        public List<T> Items { get; set; }

        public bool HasPrevious => Currentpage > 1;

        public bool HasNext => Currentpage < TotalPages;

        public PagenationVM(int currentpage, int totalPage, int pageSize, int totalNoOfRecords, List<T> items)
        {

            Currentpage = currentpage;
            TotalPages = totalPage;
            PageSize = pageSize;
            TotalNoOfRecords = totalNoOfRecords;
            Items = items;
        }
    }
}
