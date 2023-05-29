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

    public class ClassController : Controller
    {
        private readonly IClassNamesRepository _repository;
        public ClassController(IClassNamesRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            List<ClassName> allClass=await _repository.GetAll();
            return View(allClass);
        }
        
   
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Kafedras = new SelectList(_repository.GetAllKafedras(), "Id", "Name");

            return View();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create( ClassName className)
        {

            await _repository.Create(className);
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
        public async Task<IActionResult> Update(int id, ClassName className)
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
