﻿using MasterFinalProjectAdmin.Models;

namespace MasterFinalProjectAdmin.Interface
{
    public interface ITeacherRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        List<Kafedra> GetAllKafedras();
        Task<T> GetById(int Id);
        Task<T> Create(T _object);
        Task<T> Update(int id,T _object);
        Task Delete(int Id);
    }
}
