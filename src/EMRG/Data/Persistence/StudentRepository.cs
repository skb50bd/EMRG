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
    class StudentRepository : TrackingRepository<Student>, ITrackingRepository<Student>
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
                           && i.Meta.CreatedAt >= from
                           && i.Meta.CreatedAt <= to))
                       .OrderByDescending(f => f.Meta.CreatedAt)
                       .Include(f => f.Department)
                       .Include(p => p.Program)
                       .ToListAsync();

        public override async Task<IEnumerable<Student>> GetAll()
            => await Context.Students
                        .Include(f => f.Department)
                        .Include(p => p.Program)
                        .AsNoTracking()
                        .Where(e => !e.IsRemoved)
                        .ToListAsync();

        //public override async Task<Student> GetById(int id)
        //    => await Context.Students
        //                .Include(d => d.Department)
        //                .Include(p => p.Program)
        //                .FirstOrDefaultAsync(t => t.Id == id);


    }
}

