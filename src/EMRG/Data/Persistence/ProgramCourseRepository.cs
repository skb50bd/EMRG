using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Data.Core;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Brotal.Extensions;
using System.Linq;

namespace Data.Persistence
{
    public class ProgramCourseRepository : Repository<ProgramCourse>, IRepository<ProgramCourse>
    {
        public ProgramCourseRepository(AppDbContext context)
            : base(context) { }

        public override async Task<IEnumerable<ProgramCourse>> Get<T2>(
           Expression<Func<ProgramCourse, bool>> predicate,
           Expression<Func<ProgramCourse, T2>> order,
           DateTime? from = null,
           DateTime? to = null)
           => await Context.ProgramCourses
                       .AsNoTracking()
                       .OrderByDescending(f => f.Meta.CreatedAt)
                       .Include(p => p.program)
                       .Include(f => f.course)
                       .ToListAsync();

        public override async Task<IEnumerable<ProgramCourse>> GetAll()
            => await Context.ProgramCourses
                        .Include(f => f.program)
                        .Include(f => f.course)
                        .AsNoTracking()
                        .ToListAsync();

        public override async Task<ProgramCourse> GetById(int Id)
            => await Context.ProgramCourses
                        .Include(d => d.program)
                        .Include(s => s.course)
                        .FirstOrDefaultAsync(f => f.Id == Id);

    }
}
