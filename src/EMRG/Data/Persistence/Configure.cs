﻿using Data.Core;

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
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
