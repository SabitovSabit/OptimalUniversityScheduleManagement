using MasterFinalProjectAdmin.Interface;
using MasterFinalProjectAdmin.Models;
using MasterFinalProjectAdmin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterFinalProjectAdmin.Controllers
{
    [Route("[controller]")]
    public class ClassSubjectController : Controller
    {
        private readonly IClassSubjectRepository repository;
        public ClassSubjectController(IClassSubjectRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            return View(await repository.GetAll());
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Create()
        {
            var model = new ClassSubjectViewModel()
            {
                AllSubjects = await repository.GetAllSubject(),
                AllClasses = await repository.GetAllClass()
            };

            return View(model);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(int classId, int subjectId)
        {
            await repository.Create(classId, subjectId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.ClassNames = new SelectList(await repository.GetAllClass(), "Id", "Name");
            ViewBag.Subjects = new SelectList(await repository.GetAllSubject(), "Id", "Name");

            var clas = await repository.GetById(id);

            return View(clas);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update(int id, ClassSubject className)
        {
            if (await repository.Update(id, className) != null)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await repository.GetById(id) != null)
            {
                await repository.Delete(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        
        }
    }
}
