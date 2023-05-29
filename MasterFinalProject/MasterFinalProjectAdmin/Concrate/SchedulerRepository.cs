using MasterFinalProjectAdmin.Data;
using MasterFinalProjectAdmin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFinalProjectAdmin.Concrate
{
    public class SchedulerRepository 
    {
        private readonly SchoolDb _db;
        public SchedulerRepository(SchoolDb db)
        {
            _db = db;
        }
        public async Task<Scheduler> Create(Scheduler scheduler)
        {
            var find = new List<Scheduler>()
            {
                new Scheduler()
                {
                    ClassNameId = scheduler.ClassNameId,
                    SubjectId = scheduler.SubjectId,
                    TeacherId = scheduler.TeacherId
                }
            };
            if (find == null)
            {
                //_db.Schedulers.Add(new Scheduler()
                //{
                //    ClassNameId = scheduler.Id,
                //    SubjectId = scheduler.SubjectId,
                //    TeacherId = scheduler.TeacherId
                //});
                _db.Schedulers.Add(scheduler);
                await _db.SaveChangesAsync();
                return scheduler;
            }
            return null;
            }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

     
        public List<Scheduler> GetByName(string name)
        {
            var result = from teacher in _db.Teachers

                         join scheduler in _db.Schedulers on teacher.Id equals scheduler.TeacherId
                         join className in _db.ClassNames on scheduler.ClassNameId equals className.Id
                         join subject in _db.Subjects on scheduler.SubjectId equals subject.Id
                         where(teacher.Name==name)
                         select new Scheduler
                         {
                             Id = scheduler.Id,
                             TeacherId = teacher.Id,
                             ClassNameId = className.Id,
                             SubjectId = subject.Id,
                         };
            if (result != null)
            {
                return (List<Scheduler>)result;

            }
            return null;

        }

        public Task<Scheduler> GetById(int Id)
        {
            throw new NotImplementedException();
        }

      

        public Task<Scheduler> Update(Scheduler _object)
        {
            throw new NotImplementedException();
        }

        public List<Scheduler>GetAll()
        {
            var result =  from teacher in _db.Teachers

                         join scheduler in _db.Schedulers on teacher.Id equals scheduler.TeacherId
                         join className in _db.ClassNames on scheduler.ClassNameId equals className.Id
                         join subject in _db.Subjects on scheduler.SubjectId equals subject.Id
                         //where(teacher.Name==name)
                         select new Scheduler
                         {
                             Id = scheduler.Id,
                             TeacherId = teacher.Id,
                             ClassNameId = className.Id,
                             SubjectId = subject.Id,
                         };

            return (List<Scheduler>)result;
        }

      
    }
}
