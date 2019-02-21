using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Data.Core;
using Domain;
using Microsoft.EntityFrameworkCore;
using Brotal.Extensions;
using System.Linq;

namespace Data.Persistence 
{
    class ProgramRepository : TrackingRepository<Program>, ITrackingRepository<Program>
    {
        public ProgramRepository(AppDbContext context)
            : base(context){ }

        public override async Task<IEnumerable<Program>> Get<T2>(
            Expression<Func<Program, bool>> predicate,
            Expression<Func<Program, T2>> order,
            DateTime? from = null,
            DateTime? to = null)
            => await Context.Programs
                        .AsNoTracking()
                        .Where(predicate.And(i => !i.IsRemoved
                            && i.Meta.CreatedAt >= from
                            && i.Meta.CreatedAt <= to))
                        .OrderByDescending(f => f.Meta.CreatedAt)
                        .Include(f => f.Department)
                        .ToListAsync();

        public override async Task<IEnumerable<Program>> GetAll()
            => await Context.Programs
                        .Include(f => f.Department)
                        .AsNoTracking()
                        .Where(e => !e.IsRemoved)
                        .ToListAsync();
    }
}

