using Hospital_Management_System_DAL.Wrapper_Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hospital_Management_System_Shared.Paginatio
{
    public class PaginationResult<TEntity> : Result<TEntity> 
        where TEntity : class
    {
        public List<TEntity> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public PaginationResult(List<TEntity> items) => Items = items;

        public PaginationResult(bool succeeded, List<TEntity> items = default, 
            string message = null, int count = 0, int pageNumber = 1, int pageSize = 10)
        {
            Items = items;
            CurrentPage = pageNumber;
            Succeeded = succeeded;
            Message = message;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }

        public static PaginationResult<TEntity> Create(List<TEntity> items, int count, int pageNumber, int pageSize)
        {
            return new PaginationResult<TEntity>(true, items, null, count, pageNumber, pageSize);
        }
    }
}
