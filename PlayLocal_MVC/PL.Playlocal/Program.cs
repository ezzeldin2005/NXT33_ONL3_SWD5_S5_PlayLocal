using BLL.PlayLocal.Interfaces;
using BLL.PlayLocal.Repostries;
using DAL.PlayLocal.Contexts;
using DAL.PlayLocal.Models;
using Microsoft.EntityFrameworkCore;

namespace PL.Playlocal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add services to the container.

            // Add DbContext with SQL Server provider
            builder.Services.AddDbContext<PlayLocalDBcontext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register repositories

            builder.Services.AddScoped<IBookingRepository , BookingRepostiory>(); 

            builder.Services.AddScoped<ICourtPhotoRepository , CourtPhotosRepostiory>(); 

            builder.Services.AddScoped<ICourtRepository , CourtRepostiory>(); 

            builder.Services.AddScoped<IOwnerRepostry , OwnerRepostiory>();

            builder.Services.AddScoped<IPlayerRepository , PlayerRepostiory>(); 

            builder.Services.AddScoped<ISportsTypeRepository , SportsTypeRepostiory>(); 

            builder.Services.AddScoped<IVenueRepository , VenueRepostiory>(); 

            builder.Services.AddScoped<IVenueWorkingHoursRepository , VenueWorkingHoursRepostiory>();
            
            builder.Services.AddControllersWithViews(); // MVC

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=LandingPage}/{id?}");


            app.Run();  
        }
    }
}
