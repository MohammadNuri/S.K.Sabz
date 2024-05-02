using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using S.K.Sabz.Application.Interfaces.Context;
using S.K.Sabz.Application.Interfaces.FacadPatterns;
using S.K.Sabz.Application.Services.Blog.Commands.AddNewCategory;
using S.K.Sabz.Application.Services.Blog.FacadPattern;
using S.K.Sabz.Application.Services.Common;
using S.K.Sabz.Application.Services.Users.Commands;
using S.K.Sabz.Application.Services.Users.Commands.CheckUserInfo;
using S.K.Sabz.Application.Services.Users.FacadPattern;
using S.K.Sabz.Application.Services.Users.Queries.GetUserIdByPhoneNumber;
using S.K.Sabz.Common.Roles;
using S.K.Sabz.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);




//DataBase
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddDbContext<DataBaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/authentication/signin");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});


//Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
    options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
    options.AddPolicy(UserRoles.Patient, policy => policy.RequireRole(UserRoles.Patient));
});







// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBlogFacad, BlogFacad>();
builder.Services.AddScoped<IUserFacad, UserFacad>();
builder.Services.AddScoped<IAddUserInfoService, AddUserInfoService>();
builder.Services.AddScoped<ICheckUserInfoService, CheckUserInfoService>();
builder.Services.AddScoped<IGetUserIdByPhoneNumberSerivce, GetUserIdByPhoneNumberSerivce>();




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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
