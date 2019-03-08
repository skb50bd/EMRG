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
    /// <summary>
    /// This is a repository and UOW on top of entity framework.
    /// It takes away a lot of the flexibility of entity framework, 
    /// but hides the soft delete in the database from the code, which may be desirable.
    /// This pattern makes more sense if there are other db fields of a tracking nature 
    /// like last updated time and user on a lot of different entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TrackingRepository<T> : Repository<T>, ITrackingRepository<T> where T : Document
    {
        public TrackingRepository(AppDbContext context) : base(context) { }

        public override async Task<IEnumerable<T>> Get<T2>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, T2>> order,
            DateTime? from = null,
            DateTime? to = null)
            => await base.Get(
                predicate.And(i => !i.IsRemoved),
                order,
                from,
                to
            );

        public override async Task<IEnumerable<T>> GetAll()
            => await Context.Set<T>()
                        .AsNoTracking()
                        .Where(e => !e.IsRemoved)
                        .ToListAsync();

        public virtual async Task<IList<T>> GetRemovedItems()
            => await Context.Set<T>()
                        .AsNoTracking()
                        .Where(e => e.IsRemoved)
                        .ToListAsync();

        public virtual async Task Remove(int id)
        {
            var item = await GetById(id);
            item.IsRemoved = true;
        }

        public virtual async Task<bool> IsRemoved(int id)
            => await Context.Set<T>()
            .AnyAsync(e => e.Id == id && e.IsRemoved);

        public async Task<Faculty> GetByInitial(string initial)
            => await Context.Faculties
                        .Include(f => f.Sections)
                            .ThenInclude(f => f.Course)
                        .Include(s=> s.Sections)
                            .ThenInclude(s => s.Room)
                        .Include(e => e.Sections)
                            .ThenInclude(e => e.Semester)
                        .FirstOrDefaultAsync(f => f.Initial == initial);
    }
}