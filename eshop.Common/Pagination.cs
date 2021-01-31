using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eshop.Common
{
    public static class  Pagination
    {
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> Source,int PageIndex,int PageSize,out int RowCount)
        {
            RowCount = Source.Count();
            return Source.Skip((PageIndex - 1) * PageSize).Take(PageSize);
        }
    }
}
