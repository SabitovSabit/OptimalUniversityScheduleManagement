using MasterFinalProjectAdmin.Concrate;
using MasterFinalProjectAdmin.Interface;
using MasterFinalProjectAdmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFinalProjectAdmin.Controllers
{
    [Route("[controller]/[action]")]

    public class FacultyController : Controller
    {
        private IFacultyRepository<Faculty> _repository;
        public FacultyController(IFacultyRepository<Faculty> repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            List<Faculty> allClass=await _repository.GetAll();
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
        public async Task<IActionResult> Create( Faculty className)
        {

            await _repository.Create(className);
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
        public async Task<IActionResult> Update(int id, Faculty className)
        {
            if (await _repository.Update(id,className) != null)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
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
