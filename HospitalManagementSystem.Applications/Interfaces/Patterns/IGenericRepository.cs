using Hospital_Management_System_DAL.Wrapper_Response;
using Hospital_Management_System_Domains.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Interfaces.Patterns
{
    public interface IGenericRepository<TEntity>
        where TEntity : IEntity
    {
        IQueryable<TEntity> Entities { get; }

        Task<Result<IEnumerable<TEntity>>> RetunrAllEntitiesAsync();

        Task<Result<TEntity>> ReturnEntityByIdAsync(Guid id);

        Task<Result<TEntity>> InsertEntityAsync(TEntity entity);

        Task<Result<TEntity>> UpdateEntityAsync(TEntity entity);

        Task<Result<IEnumerable<TEntity>>> DeleteEntityByIdAsync(Guid id);
    }
}
