using MasterFinalProjectAdmin.Models;

namespace MasterFinalProjectAdmin.Interface
{
    public interface IClassSubjectRepository
    {
        Task<List<ClassSubject>> GetAll();
        Task<List<Subject>> GetAllSubject();
        Task<List<ClassName>> GetAllClass();
        Task Create(int classId, int subjectId);
        Task<ClassSubject> Update(int id, ClassSubject _object);
        Task Delete(int Id);
        Task<ClassSubject> GetById(int Id);
    }
}
