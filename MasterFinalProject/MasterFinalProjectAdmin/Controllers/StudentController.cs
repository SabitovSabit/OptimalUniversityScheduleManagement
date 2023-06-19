using MasterFinalProjectAdmin.Data;
using MasterFinalProjectAdmin.Interface;
using MasterFinalProjectAdmin.Models;
using MasterFinalProjectAdmin.VModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFinalProjectAdmin.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private IStudentRepository<Student> _repository;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public StudentController(IStudentRepository<Student> repository,
                                   IWebHostEnvironment env,
                                 UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Student> allClass = await _repository.GetAll();
            return View(allClass);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Classes = new SelectList(await _repository.GetAllClass(), "Id", "Name");

            return View();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(StudentVM student)
        {

            AppUser user = new AppUser()
            {
                Email = student.Email,
                UserName = student.Name,
                Fullname = student.Name
            };
            IdentityResult identityResult = await _userManager.CreateAsync(user, student.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            var roleExist = await _roleManager.RoleExistsAsync("Member");
            if (!roleExist)
            {
                 await _roleManager.CreateAsync(new IdentityRole("Member"));
            }
            await _userManager.AddToRoleAsync(user, "Member");
            await _signInManager.SignInAsync(user, true);
            Student studentEntity = new Student()
            {
                Name = student.Name,
                ClassName = student.ClassName,
                ClassNameId = student.ClassNameId,
                Email=student.Email,
            };
            await _repository.Create(studentEntity);
            return RedirectToAction("Index");

        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Classes = new SelectList(await _repository.GetAllClass(), "Id", "Name");
            var clas = await _repository.GetById(id);

            return View(clas);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] Student student)
        {
            if (await _repository.Update(student) != null)
            {
                return Ok(student);
            }
            return NotFound();
        }
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (await _repository.GetById(id) != null)
            {
                await _repository.Delete(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
