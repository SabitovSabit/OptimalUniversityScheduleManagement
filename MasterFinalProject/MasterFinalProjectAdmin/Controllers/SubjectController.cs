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
    public class SubjectController : Controller
    {
        private ISchoolRepository<Subject> _repository;
        public SubjectController(ISchoolRepository<Subject> repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            List<Subject> allClass = await _repository.GetAll();
            return View(allClass);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var subjects = await _repository.GetAll();
            return Ok(subjects);
        }
        [HttpGet]
        [Route("[action]/{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var stude = await _repository.GetById(id);
            if (stude != null)
            {
                return Ok(stude);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var stude = await _repository.GetByName(name);
            if (stude != null)
            {
                return Ok(stude);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create( Subject subject)
        {
            var clas = await _repository.Create(subject);
            if (clas != null)
            {
                return RedirectToAction("Index");


            }
            return Conflict();

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
        public async Task<IActionResult> Update( Subject subject)
        {
            if (await _repository.Update(subject) != null)
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

