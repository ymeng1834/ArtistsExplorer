using System;
namespace ApplicationCore.Models
{
    public class PagedResultSet<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Data { get; set; } // one page of items
        public int TotalRowCount { get; set; } // how many items in total
        public int PageSize { get; set; } // how many items in one page
        public int TotalPages { get; set; } // how many pages in total
        public int PageIndex { get; set; } // current page index
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public PagedResultSet(IEnumerable<TEntity> data, int pageIndex, int pageSize, int totalRowCount)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalRowCount = totalRowCount;
            Data = data;
            TotalPages = (int)Math.Ceiling(totalRowCount / (double)pageSize);
        }
    }
}

