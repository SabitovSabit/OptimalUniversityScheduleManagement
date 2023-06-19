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
    public class TeacherRepository : ITeacherRepository<Teacher>
    {
        private SchoolDb _db;
        public TeacherRepository(SchoolDb db)
        {
            _db = db;
        }
        public async Task<Teacher> Create(Teacher _object)
        {
            _db.Teachers.Add(_object);
            await _db.SaveChangesAsync();
            return _object;
        }
        public async Task Delete(int Id)
        {
            var delteacher = await GetById(Id);
            _db.Teachers.Remove(delteacher);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAll()
        {
            return await _db.Teachers.Include(x=>x.Kafedra).ToListAsync();
        }
        public List<Kafedra> GetAllKafedras()
        {
            List<Kafedra> kafedras = _db.Kafedras.ToList();

            return kafedras;
        }
        public async Task<Teacher> GetById(int Id)
        {
            var find = await _db.Teachers.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return find;
        }

        public async Task<Teacher> Update(int id,Teacher _object)
        {

            var existingStudent = await _db.Teachers.Where(s => s.Id == id).FirstOrDefaultAsync();

            if (existingStudent != null)
            {
                existingStudent.Name = _object.Name;

                await _db.SaveChangesAsync();
                return _object;
            }
            return null;

        }

        public async Task<Teacher> GetByName(string name)
        {
            return await _db.Teachers.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }

    }
}
