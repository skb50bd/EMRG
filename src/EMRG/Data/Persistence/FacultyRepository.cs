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
    public class FacultyRepository : TrackingRepository<Faculty>, ITrackingRepository<Faculty>
    {
        public FacultyRepository(AppDbContext context)
            : base(context) { }

        public override async Task<IEnumerable<Faculty>> Get<T2>(
            Expression<Func<Faculty, bool>> predicate,
            Expression<Func<Faculty, T2>> order,
            DateTime? from = null,
            DateTime? to = null)
            => await Context.Faculties
                        .AsNoTracking()
                        .Where(predicate.And(i => !i.IsRemoved
                            && i.Meta.CreatedAt >= from
                            && i.Meta.CreatedAt <= to))
                        .OrderByDescending(f => f.Meta.CreatedAt)
                        .Include(f => f.Department)
                        .Include(f => f.Sections)
                        .ToListAsync();

        public override async Task<IEnumerable<Faculty>> GetAll()
            => await Context.Faculties
                        .Include(f => f.Department)
                        .Include(f => f.Sections)
                        .AsNoTracking()
                        .Where(e => !e.IsRemoved)
                        .ToListAsync();

        public override async Task<Faculty> GetById(int Id)
            => await Context.Faculties
                        .Include(d => d.Department)
                        .Include(s => s.Sections)
                        .FirstOrDefaultAsync(f => f.Id == Id);
    }
}
