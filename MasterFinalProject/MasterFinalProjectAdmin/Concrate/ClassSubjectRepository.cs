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
    public class ClassSubjectRepository : IClassSubjectRepository
    {
        private readonly SchoolDb _db;
        public ClassSubjectRepository(SchoolDb db)
        {
            _db = db;
        }
        public async Task Create(int classId, int subjectId)
        {
            var model = new ClassSubject()
            {
                ClassNameId = classId,
                SubjectId = subjectId
            };

            await _db.ClassSubjects.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var clas = await GetById(Id);
            _db.ClassSubjects.Remove(clas);
            await _db.SaveChangesAsync();

        }

        public async Task<List<ClassSubject>> GetAll()
        {
            return await _db.ClassSubjects.Include(x => x.ClassName).Include(x => x.Subject).ToListAsync();
        }

        public async Task<List<ClassName>> GetAllClass()
        {
            return await _db.ClassNames.ToListAsync();
        }

        public async Task<List<Subject>> GetAllSubject()
        {
            return await _db.Subjects.ToListAsync();

        }

        public async Task<ClassSubject> GetById(int Id)
        {
            var find = await _db.ClassSubjects.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return find;
        }

        public async Task<ClassSubject> Update(int id, ClassSubject _object)
        {
            var existingStudent = await _db.ClassSubjects.Where(s => s.Id == id).FirstOrDefaultAsync();

            if (existingStudent != null)
            {
                existingStudent.ClassNameId = _object.ClassNameId;
                existingStudent.SubjectId = _object.SubjectId;


                await _db.SaveChangesAsync();
                return _object;
            }
            return null;
        }
    }
}
