using System.Linq;
using System.IO;
using static System.Text.Encoding;

using Domain;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace Data.Persistence
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            try
            {
                var path = @"D:\EMRG\EMRG_Entities.dgml";
                if (!File.Exists(path))
                    File.WriteAllText(path, this.AsDgml(), UTF8);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Creating DGML File for the context.\n" 
                    + e.Message);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Semester>()
                .HasAlternateKey(s => new { s.Season, s.Year });

            builder.Entity<Room>()
                .HasMany(r => r.Sections)
                .WithOne(s => s.Room)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Faculty>()
                .HasMany(f => f.Sections)
                .WithOne(s => s.Faculty)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Student>(e =>
            {
                e.OwnsOne(s => s.StudentId);
                e.HasOne(s => s.Program)
                    .WithMany(p => p.Students)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Section>()
                .OwnsOne(s => s.Schedule,
                    sc => sc.OwnsMany(
                        st => st.TimeSlots,
                        ts => ts.HasKey(t => t.Id)));

            builder.Entity<CourseEnrollment>()
                .HasOne(c => c.Student)
                .WithMany(s => s.Enrollments)
                .OnDelete(DeleteBehavior.Restrict);

            var metas =
                builder.Model.GetEntityTypes().SelectMany(
                    d => d.GetNavigations())
                        .Where(p => p.Name == nameof(Document.Meta));

            foreach (var p in metas)
                p.IsEagerLoaded = true;
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}
