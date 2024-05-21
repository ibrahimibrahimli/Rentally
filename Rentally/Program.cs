

using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Builder;

namespace Rentally
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>();

            builder.Services.AddScoped<IAboutDal, AboutDal>();
            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IValidator<About>, AboutValidation>();

            builder.Services.AddScoped<IBookingDal, BookingDal>();
            builder.Services.AddScoped<IBookingService, BookingManager>();

            builder.Services.AddScoped<ICarCategoryDal, CarCategoryDal>();
            builder.Services.AddScoped<ICarCategoryService, CarCategoryManager>();

            builder.Services.AddScoped<ICarDal, CarDal>();
            builder.Services.AddScoped<ICarService, CarManager>();

            builder.Services.AddScoped<IContactDal, ContactDal>();
            builder.Services.AddScoped<IContactService, ContactManager>();

            builder.Services.AddScoped<ICarDal, CarDal>();
            builder.Services.AddScoped<ICarService, CarManager>();

            builder.Services.AddScoped<IFeatureDal, FeatureDal>();
            builder.Services.AddScoped<IFeatureService, FeatureManager>();

            builder.Services.AddScoped<INewDal, NewDal>();
            builder.Services.AddScoped<INewService, NewManager>();

            builder.Services.AddScoped<IPositionDal, PositionDal>();
            builder.Services.AddScoped<IPositionService, PositionManager>();

            builder.Services.AddScoped<IQADal, QADal>();
            builder.Services.AddScoped<IQAService, QAManager>();

            builder.Services.AddScoped<ISliderDal, SliderDal>();
            builder.Services.AddScoped<ISliderService, SliderManager>();

            builder.Services.AddScoped<ITeamBoardDal, TeamBoardDal>();
            builder.Services.AddScoped<ITeamBoardService, TeamBoardManager>();

            builder.Services.AddScoped<ITestimonialDal, TestimonialDal>();
            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

            builder.Services.AddScoped<IUserDal, UserDal>();
            builder.Services.AddScoped<IUserService, UserManager>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            app.Run();
        }
    }
}
