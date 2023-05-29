using MasterFinalProjectAdmin.Models;

namespace MasterFinalProjectAdmin.Interface
{
    public interface IClassNamesRepository
    {
        Task<List<ClassName>> GetAll();
        List<Kafedra> GetAllKafedras();
        Task<ClassName> GetById(int Id);
        Task<ClassName> Create(ClassName _object);
        Task<ClassName> Update(int id,ClassName _object);
        Task Delete(int Id);
    }
}
