using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace Business.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAboutDal, AboutDal>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IValidator<About>, AboutValidation>();

            services.AddScoped<IBookingDal, BookingDal>();
            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<IValidator<Booking>, BookingValidation>();

            services.AddScoped<ICarCategoryDal, CarCategoryDal>();
            services.AddScoped<ICarCategoryService, CarCategoryManager>();
            services.AddScoped<IValidator<CarCategory>, CarCategoryValidation>();

            services.AddScoped<ICarDal, CarDal>();
            services.AddScoped<ICarService, CarManager>();
            services.AddScoped<IValidator<Car>, CarValidation>();

            services.AddScoped<IContactDal, ContactDal>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IValidator<Contact>, ContactValidation>();

            services.AddScoped<IFeatureDal, FeatureDal>();
            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IValidator<Feature>, FeatureValidation>();

            services.AddScoped<INewDal, NewDal>();
            services.AddScoped<INewService, NewManager>();
            services.AddScoped<IValidator<New>, NewValidation>();

            services.AddScoped<IPositionDal, PositionDal>();
            services.AddScoped<IPositionService, PositionManager>();
            services.AddScoped<IValidator<Position>, PositionValidation>();

            services.AddScoped<IQADal, QADal>();
            services.AddScoped<IQAService, QAManager>();
            services.AddScoped<IValidator<QA>, QuestionAnswerValidation>();

            services.AddScoped<ISliderDal, SliderDal>();
            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<IValidator<Slider>, SliderValidation>();

            services.AddScoped<ITeamBoardDal, TeamBoardDal>();
            services.AddScoped<ITeamBoardService, TeamBoardManager>();
            services.AddScoped<IValidator<TeamBoard>, TeamBoardValidation>();

            services.AddScoped<ITestimonialDal, TestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<IValidator<Testimonial>, TestimonialValidation>();

            services.AddScoped<IRegionDal, RegionDal>();
            services.AddScoped<IRegionService, RegionManager>();
            services.AddScoped<IValidator<Region>, RegionValidation>();

            return services;
        }
    }
}
