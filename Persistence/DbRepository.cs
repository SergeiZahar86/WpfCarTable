using Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    internal class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly EntitiesDBContext _db;
        private readonly DbSet<T> _Set;

        public bool AutoSaveChanges { get; set; } = true;

        public DbRepository(EntitiesDBContext db)
        {
            _db = db;
            _Set = db.Set<T>();
        }

        public virtual IQueryable<T> Items => _Set;










        public async Task<T[]> GetAllAsync(CancellationToken Cancel = default)
        {
            return await Items.ToArrayAsync();
        }

        public T Get(Guid id)
        {
            return Items.SingleOrDefault(item => item.Id == id);
        }

        public async Task<T> GetAsync(Guid id, CancellationToken Cancel = default)
        {
            return await Items.SingleOrDefaultAsync(item => item.Id == id, Cancel)
           .ConfigureAwait(false);
        }

        public T Add(T item)
        {
            throw new NotImplementedException();
        }

        public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }


        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Guid id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

    }
}
