using LogicLayer.Interfaces;
using LogicLayer.Classes;
using LogicLayer.Controllers;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Filters;
using LogicLayer.Strategy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = new PathString("/Login");
    options.AccessDeniedPath = new PathString("/AccessDenied");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);

});
builder.Services.AddSingleton<UserController>(new UserController(new UserDAL()));
builder.Services.AddSingleton<UserDAL>(new UserDAL());
builder.Services.AddSingleton<MediaItemController>(new MediaItemController(new MediaItemDAL()));
builder.Services.AddSingleton<MediaItemDAL>(new MediaItemDAL());
builder.Services.AddSingleton<MediaItemViewsController>(new MediaItemViewsController(new MediaItemViewsDAL()));
builder.Services.AddSingleton<MediaItemViewsDAL>(new MediaItemViewsDAL());
builder.Services.AddSingleton<ReviewController>(new ReviewController(new ReviewDAL()));
builder.Services.AddSingleton<ReviewDAL>(new ReviewDAL());
builder.Services.AddSingleton<FavoritesController>(new FavoritesController(new FavoritesDAL()));
builder.Services.AddSingleton<FavoritesDAL>(new FavoritesDAL());
builder.Services.AddSingleton<TrendingController>(new TrendingController(new TrendingDAL()));
builder.Services.AddSingleton<TrendingDAL>(new TrendingDAL());

builder.Services.AddSingleton<LogicLayer.Strategy.FilterContext>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
}
);

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

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
