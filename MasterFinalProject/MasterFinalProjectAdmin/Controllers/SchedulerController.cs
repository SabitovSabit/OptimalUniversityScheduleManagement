using MasterFinalProjectAdmin.Data;
using MasterFinalProjectAdmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFinalProjectAdmin.Controllers
{
    [Route("api/[controller]")]
    public class SchedulerController : Controller

    {
      
        private SchoolDb _db;
        public SchedulerController( SchoolDb db)
        {
            
            _db = db;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {

            var result = from teacher in _db.Teachers

                         join scheduler in _db.Schedulers on teacher.Id equals scheduler.TeacherId
                         join className in _db.ClassNames on scheduler.ClassNameId equals className.Id
                         join subject in _db.Subjects on scheduler.SubjectId equals subject.Id
                         //where(teacher.Name==name)
                         select new Scheduler
                         {
                             Id = scheduler.Id,
                             TeacherId = teacher.Id,
                             //Teacher =  teacher,
                             ClassNameId = className.Id,
                             //ClassName = className,
                             SubjectId = subject.Id,
                             //Subject = subject
                         };

            return Ok(result);

            //return await _db.Schedulers.Where(x => x.Teacher.Name == name).ToListAsync();
        }
        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetClass(string name)
        {
            var result = from classname in _db.ClassNames

                         join scheduler in _db.Schedulers on classname.Id equals scheduler.ClassNameId
                         //join className in _db.ClassNames on scheduler.ClassNameId equals className.Id
                         join subject in _db.Subjects on scheduler.SubjectId equals subject.Id
                         where (classname.Name == name)
                         select new Scheduler
                         {
                             Id = scheduler.Id,
                             //TeacherId = teacher.Id,
                             //TeacherName = teacher.Name,
                             //ClassNameId = className.Id,
                             //Class_Name = className.Name,
                             SubjectId = subject.Id,
                         };
            if (result != null)
            {
                return Ok(result);

            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetByName(string name)
        {
            var result = from teacher in _db.Teachers

                         join scheduler in _db.Schedulers on teacher.Id equals scheduler.TeacherId
                         join className in _db.ClassNames on scheduler.ClassNameId equals className.Id
                         join subject in _db.Subjects on scheduler.SubjectId equals subject.Id
                         where (teacher.Name == name)
                         select new Scheduler
                         {
                             Id = scheduler.Id,
                             TeacherId = teacher.Id,
                             ClassNameId = className.Id,
                             SubjectId = subject.Id,
                         };
            if (result != null)
            {
                return Ok(result);

            }
            return NotFound();


        }

        [HttpPost]
        [Route("[action]")]
        public async  Task<IActionResult> Create([FromBody] Scheduler scheduler)
        {


            _db.Schedulers.Add(new Scheduler()
            {
                ClassNameId = scheduler.ClassNameId,
                SubjectId = scheduler.SubjectId,
                TeacherId = scheduler.TeacherId
            });
            await _db.SaveChangesAsync();
            return Ok(scheduler);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] Scheduler scheduler)
        {
            var schedul = await _db.Schedulers.Where(x => x.Id == scheduler.Id).FirstOrDefaultAsync();
            if (schedul != null)
            {
                schedul.ClassNameId = scheduler.ClassNameId;
                schedul.SubjectId = scheduler.SubjectId;
                schedul.TeacherId = scheduler.TeacherId;
                await _db.SaveChangesAsync();
                return Ok(scheduler);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var schedul = await _db.Schedulers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (schedul != null)
            {
                _db.Schedulers.Remove(schedul);
                await _db.SaveChangesAsync();
                return Ok();
            }
            return NotFound();

        }
    }
}
