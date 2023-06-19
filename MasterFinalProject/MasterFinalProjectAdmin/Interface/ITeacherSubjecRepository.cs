using MasterFinalProjectAdmin.Models;

namespace MasterFinalProjectAdmin.Interface
{
    public interface ITeacherSubjecRepository
    {
        Task<List<TeacherSubject>> GetAll();
        Task<List<Subject>> GetAllSubject();
        Task<List<Teacher>> GetAllTeacher();
        Task Create(int teaherId, int subjectId);
        Task<TeacherSubject> Update(int id, TeacherSubject _object);
        Task Delete(int Id);
        Task<TeacherSubject> GetById(int Id);
    }
}
