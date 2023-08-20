using MasterFinalProjectUser.Data;
using MasterFinalProjectUser.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, IdentityRole>(identityOptions =>
{
    identityOptions.Password.RequiredLength = 8;
    identityOptions.Password.RequireDigit = true;
    identityOptions.Password.RequireUppercase = true;

    identityOptions.User.RequireUniqueEmail = true;
    identityOptions.Lockout.AllowedForNewUsers = true;
    identityOptions.Lockout.MaxFailedAccessAttempts = 3;
    identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
}).AddEntityFrameworkStores<SchoolDb>().AddDefaultTokenProviders();

var connectionString = builder.Configuration.GetConnectionString("Db");
builder.Services.AddDbContext<SchoolDb>(x => x.UseSqlServer(connectionString));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("Admin", "CourseModerator"));
    options.AddPolicy("CreateCoursePolicy",
         policy => policy.RequireClaim("Create Course"));
    options.AddPolicy("UpdateCoursePolicy",
         policy => policy.RequireClaim("Update Course"));
    options.AddPolicy("DetailCoursePolicy",
         policy => policy.RequireClaim("Detail Course"));
    options.AddPolicy("DeleteCoursePolicy",
         policy => policy.RequireClaim("Delete Course"));
});
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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
