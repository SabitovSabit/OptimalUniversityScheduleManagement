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
    public class FacultyRepository : IFacultyRepository<Faculty>
    {
        private readonly SchoolDb _db;
        public FacultyRepository(SchoolDb db)
        {
            _db = db;
        }
        public async Task<Faculty> Create(Faculty _object)
        {
            var find = await _db.Faculty.Where(x => x.Name == _object.Name).FirstOrDefaultAsync();
            if (find == null)
            {
                _db.Faculty.Add(_object);
                await _db.SaveChangesAsync();
                return _object;
            }
            return null;
        }
        public async Task Delete(int Id)
        {
            var clas = await GetById(Id);
            _db.Faculty.Remove(clas);
            await _db.SaveChangesAsync();
        }
        public async Task<List<Faculty>> GetAll()
        {
            List<Faculty> classNames = await _db.Faculty.ToListAsync();

            return classNames;
        }
        public async Task<Faculty> GetById(int Id)
        {
            var find = await _db.Faculty.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return find;
        }
        public async Task<Faculty> Update(int id, Faculty _object)
        {

            var existingStudent = await _db.Faculty.Where(s => s.Id == id).FirstOrDefaultAsync();

            if (existingStudent != null)
            {
                existingStudent.Name = _object.Name;

                await _db.SaveChangesAsync();
                return _object;
            }
            return null;
        }
    }
}
