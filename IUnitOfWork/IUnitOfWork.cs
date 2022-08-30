using IRepository.Data;
using System;
using System.Collections.Generic;
using System.Text;
using LuftBorn.Data.Entity.Entities;
using System.Threading.Tasks;

namespace IUnitOfWork
{
   public  interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Employee> Employee { get; }
        IBaseRepository<User> User { get; }
        int Complete();

        Task<int> Commit();
    }
}
