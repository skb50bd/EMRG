using System.Linq;

using Domain;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Room>()
                .HasMany(r => r.Sections)
                .WithOne(s => s.Room)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Faculty>()
                .HasMany(f => f.Sections)
                .WithOne(s => s.Faculty)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Student>()
                .HasOne(s => s.Program)
                .WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.Restrict);

            var metas =
                builder.Model.GetEntityTypes().SelectMany(
                    d => d.GetNavigations())
                        .Where(p => p.Name == nameof(Document.Meta));

            foreach (var p in metas)
            {
                p.IsEagerLoaded = true;
            }
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
    }
}
