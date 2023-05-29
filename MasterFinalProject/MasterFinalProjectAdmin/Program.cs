using MasterFinalProjectAdmin.Concrate;
using MasterFinalProjectAdmin.Data;
using MasterFinalProjectAdmin.Helpers;
using MasterFinalProjectAdmin.Interface;
using MasterFinalProjectAdmin.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IClassNamesRepository, ClassRepository>();
builder.Services.AddTransient<IStudentRepository<Student>, StudentRepository>();
builder.Services.AddTransient<ISchoolRepository<Teacher>, TeacherRepository>();
builder.Services.AddTransient<ISchoolRepository<Subject>, SubjectRepository>();
builder.Services.AddTransient<IRoomRepository<Room>, RoomRepository>();
builder.Services.AddTransient<IKafedraRepository<Kafedra>, KafedraRepository>();
builder.Services.AddTransient<IFacultyRepository<Faculty>, FacultyRepository>();



builder.Services.AddScoped<IViewHelper , ViewHelper>();


var connectionString = builder.Configuration.GetConnectionString("Db");
builder.Services.AddDbContext<SchoolDb>(x => x.UseSqlServer(connectionString));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
