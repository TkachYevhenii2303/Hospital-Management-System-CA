using Hospital_Management_System_Shared.Paginatio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Extensions
{
    public static class IQueryableExtensions
    {
        public static async Task<PaginationResult<TEntity>> ToPaginatedListAsync<TEntity>(this IQueryable<TEntity> source, 
            int pageNumber, int pageSize, CancellationToken cancellationToken) where TEntity : class
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = await source.CountAsync();
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            List<TEntity> items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            return PaginationResult<TEntity>.Create(items, count, pageNumber, pageSize);
        }
    }
}
