using MasterFinalProjectAdmin.Data;
using MasterFinalProjectAdmin.Interface;
using MasterFinalProjectAdmin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFinalProjectAdmin.Concrate
{
    public class StudentRepository : IStudentRepository<Student>
    {
         private SchoolDb _db;
        public StudentRepository(SchoolDb db)
        {
            _db = db;
           
        }
        
        public async Task<Student> Create(Student _object)
        {
            
            _db.Students.Add(_object);
            await _db.SaveChangesAsync();
            return _object;
        }

        public async Task Delete(int Id)
        {
            var delstudent= await GetById(Id);
            _db.Students.Remove(delstudent);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAll()
        {

            return  await _db.Students.Include(x=>x.ClassName).ToListAsync();
             
        }

        public async Task<Student> GetById(int Id)
        {
            var find = await _db.Students.Where(x => x.Id == Id).FirstOrDefaultAsync();
           
            return find;
        }

        public async Task<Student> Update(Student _object)
        {
            var existingStudent = await _db.Students.Where(s => s.Id ==_object.Id).FirstOrDefaultAsync();

            if (existingStudent != null)
            {
                existingStudent.Name = _object.Name;
                existingStudent.ClassNameId = _object.ClassNameId;

                await _db.SaveChangesAsync();
                return _object;
            }
            
            return null;

        }

        public async Task<Student> GetByName(string name)
        {
            return await _db.Students.FirstOrDefaultAsync(x=>x.Name.ToLower()==name.ToLower());
        }

        public async Task<List<ClassName>> GetAllClass()
        {
            return await _db.ClassNames.ToListAsync();
        }
    }
}
