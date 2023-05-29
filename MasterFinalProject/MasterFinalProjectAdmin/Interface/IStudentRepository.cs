using MasterFinalProjectAdmin.Models;

namespace MasterFinalProjectAdmin.Interface
{
    public interface IStudentRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int Id);
        Task<T> GetByName(string name);
        Task<T> Create(T _object);
        Task<T> Update(T _object);
        Task Delete(int Id);
        Task<List<ClassName>> GetAllClass();


    }
}
