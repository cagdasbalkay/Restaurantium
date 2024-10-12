using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Restaurantium.Business.Abstract;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.AboutValidatators;
using Restaurantium.Business.ValidationRules.BannerValidators;
using Restaurantium.Business.ValidationRules.BookingValidators;
using Restaurantium.Business.ValidationRules.CategoryValidators;
using Restaurantium.Business.ValidationRules.ChefValidators;
using Restaurantium.Business.ValidationRules.CompanySocialMediaValidators;
using Restaurantium.Business.ValidationRules.ContactValidators;
using Restaurantium.Business.ValidationRules.FoodValidators;
using Restaurantium.Business.ValidationRules.FooterContactValidators;
using Restaurantium.Business.ValidationRules.ServiceValidators;
using Restaurantium.Business.ValidationRules.SubscribeValidator;
using Restaurantium.Business.ValidationRules.TestimonialValidators;
using Restaurantium.Business.ValidationRules.WorkingHourValidators;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Concrete.Repositories;
using Restaurantium.DataAccess.Concrete.Repositories.AppUserRepositories;
using Restaurantium.DataAccess.Concrete.Repositories.FooterRepositories;
using Restaurantium.DataAccess.Concrete.Repositories.StatisticRepositories;
using Restaurantium.DataAccess.Context;
using Restaurantium.DataAccess.Entities;
using Restaurantium.DataAccess.EntityFramework;
using Restaurantium.DataAccess.Tools;
using Restaurantium.Dto.StatisticDtos;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true


    };
});

builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RestaurantiumContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IBannerDal, EfBannerDal>();
builder.Services.AddScoped<IChefDal, EfChefDal>();
builder.Services.AddScoped<ICompanySocialMediaDal, EfCompanySocialMediaDal>();
builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
builder.Services.AddScoped<IServiceDal, EfServiceDal>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<IFoodMenuDal, EfFoodMenuDal>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<IFoodDal, EfFoodDal>();
builder.Services.AddScoped<IFooterContactDal, EfFooterContactDal>();
builder.Services.AddScoped<IWorkingHourDal, EfWorkingHourDal>();
builder.Services.AddScoped<IStatisticDal, EfStatisticDal>();
builder.Services.AddScoped<IAppUserDal, EfAppUserDal>();
builder.Services.AddScoped<IProfileDal, EfProfileDal>();




builder.Services.AddScoped<IFooterDal, FooterRepository>();
//builder.Services.AddScoped<IStatisticDal, StatisticRepository>();







builder.Services.AddScoped<AboutManager>();
builder.Services.AddScoped<BannerManager>();
builder.Services.AddScoped<ChefManager>();
builder.Services.AddScoped<CompanySocialMediaManager>();
builder.Services.AddScoped<SubscribeManager>();
builder.Services.AddScoped<ServiceManager>();
builder.Services.AddScoped<TestimonialManager>();
builder.Services.AddScoped<FoodMenuManager>();
builder.Services.AddScoped<BookingManager>();
builder.Services.AddScoped<ContactManager>();
builder.Services.AddScoped<CategoryManager>();
builder.Services.AddScoped<FoodManager>();
builder.Services.AddScoped<FooterContactManager>();
builder.Services.AddScoped<WorkingHourManager>();
builder.Services.AddScoped<StatisticManager>();
builder.Services.AddScoped<AppUserManager>();
builder.Services.AddScoped<ProfileManager>();


builder.Services.AddScoped<CreateAboutValidator>();
builder.Services.AddScoped<UpdateAboutValidator>();
builder.Services.AddScoped<BannerValidator>();
builder.Services.AddScoped<BookingValidator>();
builder.Services.AddScoped<CreateCategoryValidator>();
builder.Services.AddScoped<UpdateCategoryValidator>();
builder.Services.AddScoped<ChefValidator>();
builder.Services.AddScoped<CompanySocialMediaValidator>();
builder.Services.AddScoped<ContactValidator>();
builder.Services.AddScoped<CreateFoodValidator>();
builder.Services.AddScoped<UpdateFoodValidator>();
builder.Services.AddScoped<FooterContactValidator>();
builder.Services.AddScoped<ServiceValidator>();
builder.Services.AddScoped<CreateSubscribeValidator>();
builder.Services.AddScoped<UpdateSubscribeValidator>();
builder.Services.AddScoped<TestimonialValidator>();
builder.Services.AddScoped<WorkingHourValidator>();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//        policy =>
//        {
//            policy.AllowAnyOrigin()
//                  .AllowAnyHeader()
//                  .AllowAnyMethod();
//        });
//});



var app = builder.Build();
//app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
