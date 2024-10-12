using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Restaurantium.Business.ValidationRules.AboutValidatators;
using Restaurantium.DataAccess.Entities;
using Restaurantium.Dto.AboutDtos;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IValidator<CreateAboutDto>, CreateAboutValidator>();


builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
}
);
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SetDefaultCulture("tr");
    options.AddSupportedCultures("en", "de", "tr");
    options.AddSupportedUICultures("en","de","tr");
    options.FallBackToParentUICultures = true;

    options.RequestCultureProviders.Clear();
    options.RequestCultureProviders.Add(new QueryStringRequestCultureProvider());
  


});
builder.Services.AddHttpClient();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index/";
    opt.LogoutPath = "/Login/Logout/";
    opt.AccessDeniedPath = "/Pages/AccessDenied/";
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "RestaurantiumJwt";
});



builder.Services.AddHttpContextAccessor();
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
app.UseAuthentication();
app.UseAuthorization();

//var supportedCultures = new[] { "en", "fr", "de", "tr" };
//var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[3]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);

//app.UseRequestLocalization(localizationOptions);




app.UseRequestLocalization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
