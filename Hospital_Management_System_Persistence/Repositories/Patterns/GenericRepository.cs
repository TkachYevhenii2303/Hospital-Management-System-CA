using Hospital_Management_System_Applications.Interfaces.Patterns;
using Hospital_Management_System_DAL.Wrapper_Response;
using Hospital_Management_System_Domains.Common;
using Hospital_Management_System_Domains.Common.Interfaces;
using Hospital_Management_System_Domains.Structures.WrapperResponse.Interfaces;
using Hospital_Management_System_Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Persistence.Repositories.Patterns
{
    public class GenericRepository<TEntiy> : IGenericRepository<TEntiy>
        where TEntiy : BaseAuditableEntity
    {
        private readonly HospitalManagementContext _context;

        public GenericRepository(HospitalManagementContext context)
        {
            _context = context;
        }

        public IQueryable<TEntiy> Entities => _context.Set<TEntiy>();

        public async Task<Result<IEnumerable<TEntiy>>> DeleteEntityByIdAsync(Guid id)
        {
            var resul = new Result<IEnumerable<TEntiy>>();
            
            var exist = await this.Entities.FirstOrDefaultAsync(x => x.ID == id);

            if (exist is null)
            {
                throw new KeyNotFoundException($"The specified entity ID {id} was not found in the database. Please verify the ID and try again.");
            }

            _context.Remove(exist);

            resul.Entity = await this.Entities.AsNoTracking().ToListAsync();

            resul.Message = "Deletion Successful: Your code has successfully removed the specified data from the database.";

            return resul;
        }

        public async Task<Result<TEntiy>> InsertEntityAsync(TEntiy entity)
        {
            var result = new Result<TEntiy>() { Entity = entity };  
            
            await _context.Set<TEntiy>().AddAsync(entity);

            result.Message = "The data has been successfully inserted into the table, " +
                "showcasing your expertise in database operations and precise implementation in C#. Well done!";

            return result;
        }

        public async Task<Result<IEnumerable<TEntiy>>> RetunrAllEntitiesAsync()
        {
            var result = new Result<IEnumerable<TEntiy>>();  
            
            result.Entity = await this.Entities.AsNoTracking().ToListAsync();

            result.Message = "Impressive work! Your method for fetching all entities from the database in C# is top-notch. Great job!";

            return result;
        }

        public async Task<Result<TEntiy>> ReturnEntityByIdAsync(Guid id)
        {
            var result = new Result<TEntiy>();

            result.Entity = await this.Entities.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);

            result.Message = $"Impressive work! Your method for fetching entity using its ID {id} from the database in C# is top-notch. Great job!";

            return result;
        }

        public async Task<Result<TEntiy>> UpdateEntityAsync(TEntiy entity)
        {
            var result = new Result<TEntiy>() { Entity = entity };

            result.Entity = await this.Entities.AsNoTracking().FirstOrDefaultAsync(x => x.ID == entity.ID);

            if ( result.Entity is null )
            {
                throw new KeyNotFoundException($"The specified entity ID {entity.ID} was not found in the database. Please verify the ID and try again.");
            }

            _context.Update(entity);

            result.Message = "Entity Update Successful! Your code executed flawlessly, resulting in the successful update of the entity. Great job!";

            return result;
        }
    }
}
