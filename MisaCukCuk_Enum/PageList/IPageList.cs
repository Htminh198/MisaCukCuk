using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Enum.PageList
{
    public interface IPagedList<T> : IList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }

        //Pageper GetPageper();
    }
}
