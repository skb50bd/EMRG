﻿using System;
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
    class CourseRepository : TrackingRepository<Course>, ITrackingRepository<Course>
    {
        public CourseRepository(AppDbContext context)
           : base(context) { }


        public override async Task<Course> GetById(int id)
            => await Context.Set<Course>()
                        .Include(f => f.Department)
                        .Include(f => f.Sections)
                        .Include(p => p.Prerequisites)
                            .ThenInclude(pc => pc.Course)
                        .Include(c => c.Prerequisites)
                            .ThenInclude(cp => cp.Prerequisite)
                        .FirstOrDefaultAsync(t => t.Id == id);

        public override async Task<IEnumerable<Course>> Get<T2>(
            Expression<Func<Course, bool>> predicate,
            Expression<Func<Course, T2>> order,
            DateTime? from = null,
            DateTime? to = null)
            => await Context.Courses
                        .AsNoTracking()
                        .Where(predicate.And(i => !i.IsRemoved
                            && i.Meta.CreatedAt >= from
                            && i.Meta.CreatedAt <= to))
                        .OrderByDescending(f => f.Meta.CreatedAt)
                        .Include(f => f.Department)
                        .Include(f => f.Sections)
                        .Include(c => c.Prerequisites)
                                .ThenInclude(p => p.Course)
                         .Include(c => c.Prerequisites)
                            .ThenInclude(cp => cp.Prerequisite)
                        .ToListAsync();

        public override async Task<IEnumerable<Course>> GetAll()
            => await Context.Courses
                        .Include(f => f.Department)
                        .Include(f => f.Sections)
                        .Include(c => c.Prerequisites)
                                .ThenInclude(p => p.Course)
                         .Include(c => c.Prerequisites)
                            .ThenInclude(cp => cp.Prerequisite)
                        .AsNoTracking()
                        .Where(e => !e.IsRemoved)
                        .ToListAsync();
    }
}

