using IRepository.Data;
using Data.Entity.Entities;
using Repository.Data;
using Repository.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
   public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public IBaseRepository<Employee> Employee { get; private set; }
        public IBaseRepository<User> User { get; private set; }
        public IBaseRepository<KaizanCard> KaizanCard { get; private set; }
        public IBaseRepository<Department> Department { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Employee = new BaseRepository<Employee>(_context);
            User = new BaseRepository<User>(_context);
            KaizanCard = new BaseRepository<KaizanCard>(_context);
            Department = new BaseRepository<Department>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> Commit()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
