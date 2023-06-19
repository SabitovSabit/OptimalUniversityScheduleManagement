using Dapper;
using MasterFinalProjectAdmin.Data;
using MasterFinalProjectAdmin.Interface;
using MasterFinalProjectAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MasterFinalProjectAdmin.Concrate
{
    public class TimeDayClassRepository : ITimeDayClassRepository
    {
        private readonly SchoolDb _db;
        private readonly IConfiguration config;
        public TimeDayClassRepository(SchoolDb db, IConfiguration config)
        {
            _db = db;
            this.config = config;
        }
        public async Task<TimeDayClass> Create(TimeDayClass _object)
        {
            var find = await _db.TimeDayClasses.Where(x => x.Id == _object.Id).FirstOrDefaultAsync();
            if (find == null)
            {
                _db.TimeDayClasses.Add(_object);
                await _db.SaveChangesAsync();
                return _object;
            }
            return null;
        }
        public async Task Delete(int Id)
        {
            var clas = await GetById(Id);
            _db.TimeDayClasses.Remove(clas);
            await _db.SaveChangesAsync();

        }
        public async Task<List<TimeDayClass>> GetAll()
        {
            List<TimeDayClass> classNames = await _db.TimeDayClasses.Include(x=>x.ClassName).Include(x=>x.TimeOfDay)
                                                                                 .Include(x=>x.Days).Include(x=>x.Teacher)
                                                                                  .Include(x=>x.Room).Include(x=>x.Subject).ToListAsync();

            return classNames;
        }

        public async Task<List<ClassName>> GetAllClasses()
        {
            return await _db.ClassNames.ToListAsync();
        }

        public async Task<List<Days>> GetAllDays()
        {
            return await _db.Days.ToListAsync();
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await _db.Rooms.ToListAsync();
        }

        public async Task<List<Subject>> GetAllSubjects()
        {
            return await _db.Subjects.ToListAsync();
        }

        public async Task<List<Teacher>> GetAllTeachers()
        {
            return await _db.Teachers.ToListAsync();
        }

        public async Task<List<TimeOfDay>> GetAllTimes()
        {
            return await _db.TimeOfDays.ToListAsync();
        }

        public async Task<TimeDayClass> GetById(int Id)
        {
            var find = await _db.TimeDayClasses.Where(x => x.Id == Id).Include(x=>x.ClassName).Include(x=>x.Teacher)
                                                               .Include(x=>x.Subject).Include(x=>x.Days)
                                                               .Include(x=>x.TimeOfDay).Include(x=>x.Room).FirstOrDefaultAsync();
            return find;
        }

       
        public async Task<TimeDayClass> Update(int id, TimeDayClass _object)
        {

            var existingStudent = await _db.TimeDayClasses.Where(s => s.Id == id).FirstOrDefaultAsync();

            if (existingStudent != null)
            {
                existingStudent.TeacherId = _object.TeacherId;
                existingStudent.SubjectId = _object.SubjectId;
                existingStudent.ClassNameId = _object.ClassNameId;
                existingStudent.RoomId = _object.RoomId;
                existingStudent.DaysId = _object.DaysId;
                existingStudent.TimeOfDayId = _object.TimeOfDayId;


                await _db.SaveChangesAsync();
                return _object;
            }
            return null;
        }


        public object GetSubjectByClass(int Id)
        {
            string Sql = $@"select s.id value ,s.name text from Subjects s
                                                           join ClassSubjects  cs on cs.subjectid=s.id 
                                                           join ClassNames c on c.Id=cs.classnameid
                                                           where c.id=@id";
            object MajorList;
            using (var con = new SqlConnection(config.GetValue<string>("ConnectionStrings:Db")))
            {
                MajorList = con.Query<object>(Sql, new { id = Id }).ToList();
            }
            return  MajorList;
        }

        public object GetTeacherBySubject(int Id)
        {
            string Sql = $@"select s.id value ,s.name text from Teachers s
                                   join TeacherSubjects  cs on cs.TeacherId=s.id 
                                   join Subjects c on c.Id=cs.SubjectId
                                   where c.id=@id";
            object MajorList;
            using (var con = new SqlConnection(config.GetValue<string>("ConnectionStrings:Db")))
            {
                MajorList = con.Query<object>(Sql, new { id = Id }).ToList();
            }
            return MajorList;
        }
        public object GetDaysByClass(int Id)
        {
            string Sql = $@"SELECT  MAX(d.id) value ,MAX(d.name) text 
                                   FROM Days d
                                   left JOIN TimeDayClasses td ON td.DaysId = d.id
                                   and td.ClassNameId=@id
                                   GROUP BY d.Name
                                   HAVING COUNT(td.DaysId) < 4;";
            object MajorList;
            using (var con = new SqlConnection(config.GetValue<string>("ConnectionStrings:Db")))
            {
                MajorList = con.Query<object>(Sql, new { id = Id }).ToList();
            }
            return MajorList;
        }

        public object GetDays(int teacherId, int clasId)
        {
            string Sql = $@"SELECT  MAX(d.id) value ,MAX(d.name) text 
                                   FROM Days d
                                   left JOIN TimeDayClasses td ON td.DaysId = d.id
                                   and td.TeacherId=@teacherId and td.classnameid=@clasId
                                   GROUP BY d.Name
                                   HAVING COUNT(td.DaysId) < 6;";
            object MajorList;
            using (var con = new SqlConnection(config.GetValue<string>("ConnectionStrings:Db")))
            {
                MajorList = con.Query<object>(Sql, new { teacherId = teacherId,clasId=clasId}).ToList();
            }
            return MajorList;
        }
        public object GetTimes(int teacherId,int dayId,int classId)
        {
            string Sql = $@"select t.id value ,t.name text  from TimeOfDays t
                                  where t.Id not in 
                                  (select d.TimeOfDayId from TimeDayClasses d 
                                   where (d.ClassNameId=@classId and d.DaysId=@dayId ) or (d.TeacherId=@teacherId and d.DaysId=@dayId));";
            object MajorList;
            using (var con = new SqlConnection(config.GetValue<string>("ConnectionStrings:Db")))
            {
                MajorList = con.Query<object>(Sql, new { classId = classId,teacherId=teacherId,dayId=dayId }).ToList();
            }
            return MajorList;
        }

        public object GetRooms(int timeOfDayId, int dayId)
        {
            string Sql = $@"select t.id value ,t.name text  from Rooms t
                                   where t.Id not in 
                                   (select d.RoomId from TimeDayClasses d 
                                    where d.TimeOfDayId=@timeOfDayId and d.DaysId=@dayId );";
            object MajorList;
            using (var con = new SqlConnection(config.GetValue<string>("ConnectionStrings:Db")))
            {
                MajorList = con.Query<object>(Sql, new { timeOfDayId=timeOfDayId, dayId = dayId }).ToList();
            }
            return MajorList;
        }
    }
}
