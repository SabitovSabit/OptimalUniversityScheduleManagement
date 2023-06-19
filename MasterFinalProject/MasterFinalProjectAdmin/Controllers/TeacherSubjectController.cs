using MasterFinalProjectAdmin.Interface;
using MasterFinalProjectAdmin.Models;
using MasterFinalProjectAdmin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterFinalProjectAdmin.Controllers
{
    [Route("[controller]")]
    public class TeacherSubjectController : Controller
    {
        private readonly ITeacherSubjecRepository repository;
        public TeacherSubjectController(ITeacherSubjecRepository repository)
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
            var model = new TeacherSubjectViewModel()
            {
                AllSubjects = await repository.GetAllSubject(),
                AllTeachers = await repository.GetAllTeacher()
            };
            
            return View(model);
        }
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> Create(int teacherId,int subjectId)
        {
            
            await repository.Create(teacherId, subjectId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Teachers = new SelectList(await repository.GetAllTeacher(), "Id", "Name");
            ViewBag.Subjects = new SelectList(await repository.GetAllSubject(), "Id", "Name");

            var clas = await repository.GetById(id);

            return View(clas);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update(int id, TeacherSubject className)
        {
            if (await repository.Update(id, className) != null)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteC(int id)
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
