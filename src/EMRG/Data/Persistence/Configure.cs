using Data.Core;

using Domain;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Persistence
{
    public static class Configure
    {
        public static IServiceCollection ConfigureData(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDefaultIdentity<AppUser>()
                        .AddRoles<IdentityRole>()
                        .AddDefaultUI(UIFramework.Bootstrap4)
                        .AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<ITrackingRepository<Department>, TrackingRepository<Department>>();
            services.AddTransient<ITrackingRepository<Faculty>, FacultyRepository>();
            services.AddTransient<ITrackingRepository<Program>, ProgramRepository>();
            services.AddTransient<ITrackingRepository<Student>, StudentRepository>();
            services.AddTransient<ITrackingRepository<Course>, CourseRepository>();
            services.AddTransient<ITrackingRepository<Room>, TrackingRepository<Room>>();
            services.AddTransient<ITrackingRepository<Semester>, TrackingRepository<Semester>>();
            services.AddTransient<ITrackingRepository<Section>, TrackingRepository<Section>>();
            services.AddTransient<IRepository<CourseEnrollment>, Repository<CourseEnrollment>>();
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
