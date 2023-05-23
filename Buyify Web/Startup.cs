using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace Buyify_Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuration des services, y compris la configuration de la base de données
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(_configuration.GetConnectionString("DefaultConnection")));

            services.AddRazorPages();
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("id", typeof(IntRouteConstraint));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}"); // Redirige vers la page de connexion

                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "details",
                    pattern: "Details/{int:id}",
                    defaults: new { controller = "Details", action = "Index" });
            });
        }
    }
}
