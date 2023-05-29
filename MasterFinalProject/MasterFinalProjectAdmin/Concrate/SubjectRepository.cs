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
    public class SubjectRepository:ISchoolRepository<Subject>
    {
        private SchoolDb _db;
        public SubjectRepository(SchoolDb db)
        {
            _db = db;
        }
        public async Task<Subject> Create(Subject _object)
        {
            var find = await _db.Subjects.Where(x => x.Name == _object.Name).FirstOrDefaultAsync();
            if (find == null)
            {
                _db.Subjects.Add(_object);
                await _db.SaveChangesAsync();
                return _object;
            }

            return null;
        }

        public async Task Delete(int Id)
        {
            var clas = await GetById(Id);
            _db.Subjects.Remove(clas);
            await _db.SaveChangesAsync();

        }

        public async Task<List<Subject>> GetAll()
        {
            return await _db.Subjects.ToListAsync();
        }
        public async Task<Subject> GetById(int Id)
        {
            var find = await _db.Subjects.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return find;
        }

        public async Task<Subject> GetByName(string name)
        {
            return await _db.Subjects.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task<Subject> Update(Subject _object)
        {
            
            var existingStudent = await _db.Subjects.Where(s => s.Id == _object.Id).FirstOrDefaultAsync();



            if (existingStudent != null)
            {
                existingStudent.Name = _object.Name;

                await _db.SaveChangesAsync();
                return _object;
            }
            //_db.Students.Update(_object);
            //await _db.SaveChangesAsync();
            return null;


        }

    }
}
