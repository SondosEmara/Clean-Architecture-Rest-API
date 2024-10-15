using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Layer.Wrappers
{
    public class PagniationResult<T>
    {
        public PagniationResult()
        {
        }

        public PagniationResult(List<T>_data,int _currentPage,int _totalCount,int _pageSize,bool _succeded)
        {
            Data = _data;
            CurrentPage = _currentPage;
            IfSucceeed = _succeded;
            PageSize = _pageSize;
            TotalCount = _totalCount;
            TotalPages =(int)Math.Ceiling(TotalCount/(double)PageSize);
        }

        public List<T>Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
      
        public object Meta {  get; set; }

        public bool IfSucceeed { get; set; }
        public bool HasNextPage => CurrentPage <= TotalPages;
        public bool HasPreviousPage=> CurrentPage > 1;
        public List<String> Messages { get; } = new(); 
      
    }
}
