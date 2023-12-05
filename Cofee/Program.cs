using Cofee.Data;
using Cofee.Models;
using Cofee.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cofee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                //options.UseSqlServer(connectionString));
                options.UseNpgsql(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //�����������, ��������� �� ��� ����� ��������������
            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            //���������� �����������
            builder.Services.AddTransient<NewsRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.MapControllerRoute(
            //    name: "admin",
            //     // pattern: "admin/{*id}"
            //     //defaults: new { controller = "admin", action = "Index" }
            //     pattern: "{controller=Admin}/{action=Index}/{id?}");


            //app.MapControllerRoute("admin", "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
            //app.MapControllerRoute(
            //name: "Admin",// or name: "areas",
            //pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
            //������������� ������ ��� �������� (���������)
            //app.UseEndpoints(endpoints =>
            //{
            //    // endpoints.MapControllerRoute(name: "api", "api/{controller=UploadFile}");
            //    endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=admin}/{id?}");
            //    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            //    endpoints.MapControllerRoute("api", "api/{controller=Values}");
            //    endpoints.MapRazorPages();
            //    endpoints.MapControllers(); //��� ������ � ���
            //    //endpoints.MapBlazorHub();  // ��� ������ � Blaz
            //    //endpoints.MapHub<NotificationHub>("/notification"); // ���������� ����� ������� � ������� SignalR  
            //});

            app.MapRazorPages();

            app.Run();
        }
    }
}
