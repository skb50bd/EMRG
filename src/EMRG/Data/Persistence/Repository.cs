using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Data.Core;

using Domain;

using Microsoft.EntityFrameworkCore;

using Brotal.Extensions;



namespace Data.Persistence
{
    public class Repository<T> : IRepository<T> where T : Document
    {
        protected readonly AppDbContext Context;
        public Repository(AppDbContext context)
        {
            Context = context;
        }

        public virtual async Task<IEnumerable<T>> Get<T2>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, T2>> order,
            DateTime? from = null,
            DateTime? to = null)
        {
            predicate = predicate.And(
                e => e.Meta.CreatedAt >= (from ?? DateTime.MinValue)
                    && e.Meta.CreatedAt <= (to ?? DateTime.MaxValue));

            return await Context.Set<T>()
                        .Where(predicate)
                        .OrderByDescending(order)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
            => await Context.Set<T>()
                        .AsNoTracking()
                        .ToListAsync();

        public virtual async Task<T> GetById(int id)
            => await Context.Set<T>()
                        .FirstOrDefaultAsync(t => t.Id == id);

        public virtual void Add(T item)
            => Context.Add(item);

        public virtual void AddAll(IEnumerable<T> items)
            => Context.AddRange(items);

        public virtual async Task<bool> Exists(int id)
            => await Context.Set<T>()
                        .AnyAsync(e => e.Id == id);

        public virtual async Task Delete(int id)
            => Context.Remove(await GetById(id));

        public async Task<int> Count(DateTime? from = null, DateTime? to = null)
            => await Context.Set<T>()
                .AsNoTracking()
                .Where(e =>
                    e.Meta.CreatedAt >= (from ?? DateTime.MinValue)
                    && e.Meta.CreatedAt <= (to ?? DateTime.MaxValue)
                ).CountAsync();
    }
}