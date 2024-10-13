using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Layer.Wrappers
{
    public static class QuerableExtenstions
    {
        public static async Task<PagniationResult<T>> ToPaginaedListAsync<T>(this IQueryable<T>dataSource,int pageSize,int pageNumber) where T : class
        {
            if(dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            
            int dataCount=await dataSource.AsNoTracking().CountAsync();
            if(dataCount == 0 ) return new PagniationResult<T>(new List<T>(),pageNumber,dataCount,pageSize,false);

            var dataItems =await dataSource
                                   .AsNoTracking()
                                   .Skip((pageNumber-1)*pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();
            return new PagniationResult<T>(dataItems, pageNumber, dataCount, pageSize, true);

        }
    }
}
