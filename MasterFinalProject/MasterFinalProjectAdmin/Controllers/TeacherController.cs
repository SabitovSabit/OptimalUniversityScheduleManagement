using MasterFinalProjectAdmin.Interface;
using MasterFinalProjectAdmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFinalProjectAdmin.Controllers
{
    [Route("api/[controller]")]
    public class TeacherController : Controller
    {
        private ISchoolRepository<Teacher> _repository;
        public TeacherController(ISchoolRepository<Teacher> repository)
        {
            _repository = repository;
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

            return View();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(Teacher teacher)
        {


            var stude = await _repository.Create(teacher);
            return RedirectToAction("Index");


        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Update(int id)
        {
            var clas = await _repository.GetById(id);

            return View(clas);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update( Teacher teacher)
        {
            if (await _repository.Update(teacher) != null)
            {
                return RedirectToAction("Index");

            }
            return NotFound();
        }
        [Route("[action]")]
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
