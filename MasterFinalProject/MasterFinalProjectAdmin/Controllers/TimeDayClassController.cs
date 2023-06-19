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

    public class TimeDayClassController : Controller
    {
        private readonly ITimeDayClassRepository _repository;
        public TimeDayClassController(ITimeDayClassRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            List<TimeDayClass> allClass=await _repository.GetAll();
            return View(allClass);
        }
        
   
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> classItems = new List<SelectListItem>();

            var d = await _repository.GetAllClasses();
            foreach (var x in d)
            {
                classItems.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            }

            ViewBag.Classes = classItems;

            //ViewBag.Classes = new SelectList(await _repository.GetAllClasses(), "Id", "Name");
            ViewBag.Times = new SelectList(await _repository.GetAllTimes(), "Id", "Name");
            ViewBag.Days = new SelectList(await _repository.GetAllDays(), "Id", "Name");
            ViewBag.Rooms = new SelectList(await _repository.GetAllRooms(), "Id", "Name");
            ViewBag.Teachers = new SelectList(await _repository.GetAllTeachers(), "Id", "Name");
            ViewBag.Subjects = new SelectList(await _repository.GetAllSubjects(), "Id", "Name");


            return View();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(TimeDayClass className)
        {

            await _repository.Create(className);
            return RedirectToAction("Index");

        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Update(int id)
        {
            List<SelectListItem> classItems = new List<SelectListItem>();

            var d = await _repository.GetAllClasses();
            foreach (var x in d)
            {
                classItems.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            }

            ViewBag.Classes = classItems;
            var clas = await _repository.GetById(id);

            return View(clas);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update(int id, TimeDayClass className)
        {
            if (await _repository.Update(id,className) != null)
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
        public JsonResult GetSubjectByClass(int Id)
        {
            var resp= _repository.GetSubjectByClass(Id);
            return Json(resp);
        }
        public JsonResult GetTeacherBySubject(int Id)
        {
            var resp = _repository.GetTeacherBySubject(Id);
            return Json(resp);
        }
        public JsonResult GetDaysByClass(int Id)
        {
            var resp = _repository.GetDaysByClass(Id);
            return Json(resp);
        }
        public JsonResult GetDays(int TeacherId,int ClassId)
        {
            var resp = _repository.GetDays( TeacherId,ClassId);
            return Json(resp);
        }
        public JsonResult GetTimes(int TeacherId,int DayId,int ClassId)
        {
            var resp = _repository.GetTimes(TeacherId,DayId,ClassId);
            return Json(resp);
        }
        public JsonResult GetRooms(int TimeId, int DayId)
        {
            var resp = _repository.GetRooms(TimeId, DayId);
            return Json(resp);
        }
    }
}
