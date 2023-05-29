using MasterFinalProjectAdmin.Data;
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
    public class StudentController : Controller
    {
        private IStudentRepository<Student> _repository;
        private readonly SchoolDb _db;
        public StudentController(IStudentRepository<Student> repository, SchoolDb db)
        {
            _db = db;
            _repository = repository;
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
        public async Task<IActionResult> Create(Student student)
        {

            await _repository.Create(student);
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
        [HttpDelete]
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
