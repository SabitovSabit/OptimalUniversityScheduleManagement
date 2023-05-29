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
    public class KafedraRepository : IKafedraRepository<Kafedra>
    {
        private readonly SchoolDb _db;
        public KafedraRepository(SchoolDb db)
        {
            _db = db;
        }
        public async Task<Kafedra> Create(Kafedra _object)
        {
            var find = await _db.Kafedras.Where(x => x.Name == _object.Name).FirstOrDefaultAsync();
            if (find == null)
            {
                _db.Kafedras.Add(_object);
                await _db.SaveChangesAsync();
                return _object;
            }
            return null;
        }
        public async Task Delete(int Id)
        {
            var clas = await GetById(Id);
            _db.Kafedras.Remove(clas);
            await _db.SaveChangesAsync();

        }
        public async Task<List<Kafedra>> GetAll()
        {
            List<Kafedra> classNames = await _db.Kafedras.Include(x => x.Faculty).ToListAsync();

            return classNames;
        }
        public List<Faculty> GetAllFaculty()
        {
            List<Faculty> kafedras = _db.Faculty.ToList();

            return kafedras;
        }
        public async Task<Kafedra> GetById(int Id)
        {
            var find = await _db.Kafedras.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return find;
        }

        public async Task<Kafedra> Update(int id, Kafedra _object)
        {

            var existingStudent = await _db.Kafedras.Where(s => s.Id == id).FirstOrDefaultAsync();

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
