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
    public class ClassRepository : IClassNamesRepository
    {
        private readonly SchoolDb _db;
        public ClassRepository(SchoolDb db)
        {
            _db = db;
        }
        public async Task<ClassName> Create(ClassName _object)
        {
            var find = await _db.ClassNames.Where(x => x.Name == _object.Name).FirstOrDefaultAsync();
            if (find == null)
            {
                _db.ClassNames.Add(_object);
                await _db.SaveChangesAsync();
                return _object;
            }
            return null;
        }
        public async Task Delete(int Id)
        {
            var clas = await GetById(Id);
            _db.ClassNames.Remove(clas);
            await _db.SaveChangesAsync();

        }
        public async Task<List<ClassName>> GetAll()
        {
            List<ClassName> classNames = await _db.ClassNames.Include(x => x.Kafedra).ToListAsync();

            return classNames;
        }
        public List<Kafedra> GetAllKafedras()
        {
            List<Kafedra> kafedras = _db.Kafedras.ToList();

            return kafedras;
        }
        public async Task<ClassName> GetById(int Id)
        {
            var find = await _db.ClassNames.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return find;
        }

       
        public async Task<ClassName> Update(int id, ClassName _object)
        {

            var existingStudent = await _db.ClassNames.Where(s => s.Id == id).FirstOrDefaultAsync();

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
