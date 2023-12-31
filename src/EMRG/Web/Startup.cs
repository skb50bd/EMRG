using Data.Persistence;
using AutoMapper;
using Web.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Web.AuthEmailSender;
using Swashbuckle.AspNetCore.Swagger;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(m => m.AddProfile<MappingProfile>());

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var cnn = Configuration.GetConnectionString("DefaultConnection");
            services.ConfigureData(cnn);

            services.AddAuthorization(options => {
                options.AddPolicy("SystemAdminRights", 
                    policy => policy.RequireRole("SysAdmin"));

                options.AddPolicy("DepartmentAdminRights", 
                    policy => policy.RequireRole("DepartmentAdmin"));

                options.AddPolicy("FacultyAdminRights", 
                    policy => policy.RequireRole("Faculty"));

                options.AddPolicy("StudentAdminRights", 
                    policy => policy.RequireRole("Student"));
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
                )
                .AddRazorPagesOptions(
                    options =>
                    {
                        options.Conventions.AuthorizeAreaFolder("Admin", "/*", "SystemAdminRights");
                        options.Conventions.AuthorizeAreaFolder("DepartmentAdmin", "/*", "DepartmentAdminRights");
                        options.Conventions.AuthorizeAreaFolder("FacultyZone", "/*", "FacultyAdminRights");
                        options.Conventions.AuthorizeAreaFolder("Student", "/*", "StudentAdminRights");
                    }
                );


            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new Info {
                        Title = "EMRG_API",
                        Version = "v1"
                    });
            });

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration.GetSection("SendGrid"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc();

            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EMRG_API");
            });
        }
    }
}
