using MasterFinalProjectAdmin.Interface;
using MasterFinalProjectAdmin.Models;
using MasterFinalProjectAdmin.VModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFinalProjectAdmin.Controllers
{
    [Route("api/[controller]")]
    public class TeacherController : Controller
    {
        private ITeacherRepository<Teacher> _repository;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public TeacherController(ITeacherRepository<Teacher> repository,
                                 IWebHostEnvironment env,
                                 UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _repository = repository;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Teacher> allClass = await _repository.GetAll();
            return View(allClass);
        }
      
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = new List<string> { "Admin", "CourseModerator"};
            ViewBag.Kafedras = new SelectList(_repository.GetAllKafedras(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(TeacherVM teacher)
        {

            AppUser user = new AppUser()
            {
                Email = teacher.Email,
                UserName = teacher.Name,
                Fullname=teacher.Name

            };

            IdentityResult identityResult = await _userManager.CreateAsync(user, teacher.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();

                }
            }
            var roleExist = await _roleManager.RoleExistsAsync(teacher.RoleTeacher);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole(teacher.RoleTeacher));
            }
            await _userManager.AddToRoleAsync(user, teacher.RoleTeacher);
            await _signInManager.SignInAsync(user, true);
            Teacher teacherEntity = new Teacher()
            {
                Name = teacher.Name,
                Kafedra = teacher.Kafedra,
                KafedraId = teacher.KafedraId,
                Email = teacher.Email
            };
            var stude = await _repository.Create(teacherEntity);


            return RedirectToAction("Index");

        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Kafedras = new SelectList(_repository.GetAllKafedras(), "Id", "Name");
            var clas = await _repository.GetById(id);

            return View(clas);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update(int id, Teacher teacher)
        {
            if (await _repository.Update(id,teacher) != null)
            {
                return RedirectToAction("Index");

            }
            return NotFound();
        }
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _repository.GetById(id) != null)
            {
                await _repository.Delete(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
