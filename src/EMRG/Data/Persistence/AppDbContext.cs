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
            builder.Owned<Metadata>();
            builder.Entity<Metadata>().HasKey(m => m.Id);



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
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties{ get; set; }
    }
}
