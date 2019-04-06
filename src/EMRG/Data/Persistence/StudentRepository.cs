using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Brotal.Extensions;

using Data.Core;

using Domain;

using Microsoft.EntityFrameworkCore;


namespace Data.Persistence
{
    internal class StudentRepository : TrackingRepository<Student>, ITrackingRepository<Student>
    {
        public StudentRepository(AppDbContext context)
            : base(context) { }

        public override async Task<IEnumerable<Student>> Get<T2>(
           Expression<Func<Student, bool>> predicate,
           Expression<Func<Student, T2>> order,
           DateTime? from = null,
           DateTime? to = null)
           => await Context.Students
                       .AsNoTracking()
                       .Where(predicate.And(i => !i.IsRemoved
                           && i.Meta.CreatedAt >= (from ?? DateTime.MinValue)
                           && i.Meta.CreatedAt <= (to ?? DateTime.MaxValue)))
                       .OrderByDescending(order)
                       .Include(f => f.Department)
                       .Include(p => p.Program)
                       .Include(s => s.Enrollments)
                            .ThenInclude(e => e.Section)
                            .ThenInclude(s => s.Semester)
                       .Include(s => s.Enrollments)
                            .ThenInclude(e => e.Section)
                            .ThenInclude(e => e.Course)
                       .ToListAsync();

        public override async Task<IEnumerable<Student>> GetAll()
            => await Context.Students
                        .Include(f => f.Department)
                        .Include(p => p.Program)
                        .Include(s => s.Enrollments)
                            .ThenInclude(e => e.Section)
                            .ThenInclude(s => s.Semester)
                        .Include(s => s.Enrollments)
                            .ThenInclude(e => e.Section)
                            .ThenInclude(e => e.Course)
                        .AsNoTracking()
                        .Where(e => !e.IsRemoved)
                        .ToListAsync();

        public override async Task<Student> GetById(int id)
            => await Context.Students
                        .Include(d => d.Department)
                        .Include(p => p.Program)
                        .Include(s => s.Enrollments)
                            .ThenInclude(e => e.Section)
                            .ThenInclude(s => s.Semester)
                        .Include(s => s.Enrollments)
                            .ThenInclude(e => e.Section)
                            .ThenInclude(e => e.Course)
                        .FirstOrDefaultAsync(t => t.Id == id);
    }
}

