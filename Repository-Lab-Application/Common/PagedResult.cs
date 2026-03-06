using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Application.Common
{
    public class PagedResult<T> where T : class
    {
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 20;

        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
        public IEnumerable<T> Data { get; set; } =  Enumerable.Empty<T>();

    }
}
