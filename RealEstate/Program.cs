using Microsoft.AspNetCore.Authentication.Cookies;
using RealEstate.Context;
using RealEstate.Services;

namespace RealEstate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddNpgsql<RealEstateContext>(builder.Configuration.GetConnectionString("DbAddress"));

            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<ProduitService>();
            builder.Services.AddLogging();
            builder.Services.AddRazorPages();
            builder.Services.AddMvc();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(1); // Set the expiration time as needed
                options.SlidingExpiration = true;
            });
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = "realestate.session";
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //app.MapRazorPages();
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Web}/{action=Index}");

            app.Run();
        }
    }
}
