using MasterFinalProjectUser.Data;
using MasterFinalProjectUser.Models;
using MasterFinalProjectUser.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MasterFinalProjectUser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        private readonly SchoolDb db;

        public HomeController(ILogger<HomeController> logger,
                              SchoolDb db,
                              UserManager<AppUser> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            AppUser appUsers = await userManager.GetUserAsync(User);
            List<TimeDayClass> scheduler = new List<TimeDayClass>();
            SchedulerVM schedulerVM = new SchedulerVM();
            if (appUsers != null)
            {

                var role = await db.UserRoles.Where(x => x.UserId == appUsers.Id).FirstOrDefaultAsync();

                var roleName = db.Roles.Where(x => x.Id == role.RoleId).FirstOrDefault().Name;

                int classId = 0;
                int teacherId = 0;
                if (roleName == "Member")
                {
                    var classname = db.Students.Where(x => x.Email == appUsers.Email).FirstOrDefault();

                    if (classname != null)
                    {
                        classId = classname.ClassNameId;
                        scheduler = await db.TimeDayClasses.Include(x => x.ClassName).Include(x => x.TimeOfDay)
                                                                                            .Include(x => x.Days).Include(x => x.Teacher)
                                                                                             .Include(x => x.Room).Include(x => x.Subject)
                                                                                             .Where(x => x.ClassName.Id == classId)
                                                                                             .OrderBy(x => x.TimeOfDay).OrderBy(x => x.DaysId)
                                                                                             .ToListAsync();
                    }
                    schedulerVM.IsTeacher = false;
                }
                else
                {
                    var teacher = db.Teachers.Where(x => x.Email == appUsers.Email).FirstOrDefault();
                    if (teacher !=null)
                    {
                        teacherId = teacher.Id;
                        scheduler = await db.TimeDayClasses.Include(x => x.ClassName).Include(x => x.TimeOfDay)
                                                                                           .Include(x => x.Days).Include(x => x.Teacher)
                                                                                            .Include(x => x.Room).Include(x => x.Subject)
                                                                                            .Where(x => x.TeacherId == teacherId)
                                                                                            .OrderBy(x => x.TimeOfDay).OrderBy(x => x.DaysId)
                                                                                            .ToListAsync();
                    }
                    schedulerVM.IsTeacher = true;
                }
            }
            schedulerVM.scheduers = scheduler;
            return View(schedulerVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}