using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityCustom.Areas.Identity.Data;
using AdService.UI.Middlewares;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace IdentityCustom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

            //logger
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(LogLevel.Information);
            builder.Logging.AddNLogWeb();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            //builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password = new PasswordOptions
                {
                    RequireDigit = true,
                    RequiredLength = 8,
                    RequireLowercase = true,
                    RequireUppercase = true,
                    RequireNonAlphanumeric = true
                };
            })
            .AddErrorDescriber<IdentityErrorDescriber>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

            builder.Services.Configure<PasswordHasherOptions>(opt => opt.IterationCount = 600_000);

            builder.Services.AddSession(options =>
            {
                // Ustawienia zabezpieczeñ sesji
                options.Cookie.HttpOnly = true; // Zapobiega dostêpowi do ciasteczka z poziomu JavaScript
                options.Cookie.IsEssential = true; // Oznacza ciasteczko jako niezbêdne, nawet jeœli sesja nie jest aktywna
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Czas wygaœniêcia sesji
                options.Cookie.SameSite = SameSiteMode.Strict; // Zapobiega atakom CSRF
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();;
            app.UseAuthorization();

            // Dodanie obs³ugi sesji do potoku middleware'ów
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();


            app.Run();
        }
    }
}