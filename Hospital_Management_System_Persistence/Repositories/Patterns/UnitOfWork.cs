using Hospital_Management_System_Applications.Interfaces.Patterns;
using Hospital_Management_System_Domains.Common;
using Hospital_Management_System_Persistence.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Persistence.Repositories.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalManagementContext _context;
        private Hashtable _repositories;
        private bool _disposed;

        public UnitOfWork(HospitalManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Dispose() => _context.Dispose();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseAuditableEntity
        {
            if (_repositories is null) { _repositories = new Hashtable(); }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                
                _repositories.Add(type, repositoryInstance);
            }

            return _repositories[type] as IGenericRepository<TEntity>;

        }

        public Task Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload()); 
            return Task.CompletedTask;
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
        {
            throw new NotImplementedException();
        }
    }
}
