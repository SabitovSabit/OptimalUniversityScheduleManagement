using MasterFinalProjectAdmin.Models;

namespace MasterFinalProjectAdmin.Interface
{
    public interface ITimeDayClassRepository
    {
        Task<List<TimeDayClass>> GetAll();
        Task<List<TimeOfDay>> GetAllTimes();
        Task<List<Days>> GetAllDays();
        Task<List<Room>> GetAllRooms();
        Task<List<Teacher>> GetAllTeachers();
        Task<List<Subject>> GetAllSubjects();
        Task<List<ClassName>> GetAllClasses();

        Task<TimeDayClass> GetById(int Id);
        Task<TimeDayClass> Create(TimeDayClass _object);
        Task<TimeDayClass> Update(int id, TimeDayClass _object);
        Task Delete(int Id);

        object GetSubjectByClass(int Id);
        object GetTeacherBySubject(int Id);
        object GetDaysByClass(int Id);

        object GetDays(int teacherId, int clasId);

        object GetTimes(int teacherId, int dayId, int classId);

        object GetRooms(int timeOfDayId, int dayId);

    }
}
