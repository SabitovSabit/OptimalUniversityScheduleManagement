using MasterFinalProjectAdmin.Data;
using MasterFinalProjectAdmin.Interface;
using MasterFinalProjectAdmin.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterFinalProjectAdmin.Concrate
{
    public class TeacherSubjectRepository:ITeacherSubjecRepository
    {
        private SchoolDb _db;
        public TeacherSubjectRepository(SchoolDb db)
        {
            _db = db;
        }

        public async Task Create(int teaherId,int subjectId)
        {
            var model = new TeacherSubject()
            {
                TeacherId = teaherId,
                SubjectId = subjectId
            };

            await _db.TeacherSubjects.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var clas = await GetById(Id);
            _db.TeacherSubjects.Remove(clas);
            await _db.SaveChangesAsync();

        }
        public async Task<List<TeacherSubject>> GetAll()
        {
            return await _db.TeacherSubjects.Include(x => x.Teacher).Include(x=>x.Subject).ToListAsync();
        }

        public async Task<List<Subject>> GetAllSubject()
        {
            return await _db.Subjects.ToListAsync();
        }

        public async Task<List<Teacher>> GetAllTeacher()
        {
            return await _db.Teachers.ToListAsync();
        }

        public async Task<TeacherSubject> GetById(int Id)
        {
            var find = await _db.TeacherSubjects.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return find;
        }

        public async Task<TeacherSubject> Update(int id, TeacherSubject _object)
        {
            var existingStudent = await _db.TeacherSubjects.Where(s => s.Id == id).FirstOrDefaultAsync();

            if (existingStudent != null)
            {
                existingStudent.TeacherId = _object.TeacherId;
                existingStudent.SubjectId = _object.SubjectId;


                await _db.SaveChangesAsync();
                return _object;
            }
            return null;
        }
    }
}
