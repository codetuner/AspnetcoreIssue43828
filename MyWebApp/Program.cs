// This project reproduces the issue described in:
// https://github.com/dotnet/aspnetcore/issues/43828

using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using MyLocalizationLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Install custom Localizers from MyLocalization library:
// This library has a package reference to "Microsoft.AspNetCore.Mvc.Localization" that is incompatible with this ASP.NET Core 6.0 project:
builder.Services.AddScoped<IStringLocalizer>(provider => { return new MyLocalizer(); });
builder.Services.AddScoped<IHtmlLocalizer>(provider => { return new MyLocalizer(); });
builder.Services.AddScoped<IViewLocalizer>(provider => { return new MyLocalizer(); });

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
