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
    public class RoomRepository : IRoomRepository<Room>
    {
         private SchoolDb _db;
        public RoomRepository(SchoolDb db)
        {
            _db = db;
           
        }
        
        public async Task<Room> Create(Room _object)
        {
            
            _db.Rooms.Add(_object);
            await _db.SaveChangesAsync();
            return _object;
        }

        public async Task Delete(int Id)
        {
            var delstudent= await GetById(Id);
            _db.Rooms.Remove(delstudent);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Room>> GetAll()
        {

            return  await _db.Rooms.ToListAsync();
             
        }

        public async Task<Room> GetById(int Id)
        {
            var find = await _db.Rooms.Where(x => x.Id == Id).FirstOrDefaultAsync();
           
            return find;
        }

        public async Task<Room> Update(Room _object)
        {
            var existingStudent = await _db.Rooms.Where(s => s.Id ==_object.Id).FirstOrDefaultAsync();

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
