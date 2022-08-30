using IRepository.Data;
using Data.Entity.Entities;
using Repository.Data;
using Repository.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Entity.Entities.Qrm;
using Data.Entity.Entities.KaizenCard;

namespace Repository.Data
{
    class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        public IBaseRepository<User> User { get; private set; }    
        public IBaseRepository<KaizenCardHeader> KaizenCardHeader { get; private set; }
        public IBaseRepository<KaizenCardDetails> KaizenCardDetails { get; private set; }
        public IBaseRepository<KaizenCardIssuerDetails> KaizenCardIssuerDetails { get; private set; }
        public IBaseRepository<UnitArea> UnitArea { get; private set; }
        public IBaseRepository<Department> Department { get; private set; }
        public IBaseRepository<Sections> Sections { get; private set; }
        public IBaseRepository<Page> Page { get; private set; }
        public IBaseRepository<PageLocalization> PageLocalization { get; private set; }
        public IBaseRepository<PageAction> PageAction { get; private set; }
        public IBaseRepository<ImpoventAreaType> ImpoventAreaType { get; private set; }
        public IBaseRepository<FinanceVertification> FinanceVertification { get; set; }


        public IBaseRepository<Currency> Currency { get; private set; }
        public IBaseRepository<KaizenCardImprovment> KaizenCardImprovment { get; private set; }
        public IBaseRepository<A3details> A3detail { get; private set; }
        public IBaseRepository<A3header> A3Header { get; private set; }
        public IBaseRepository<ActionsPlan> ActionsPlan { get; private set; }
        public IBaseRepository<QrmImprovment> QrmImprovment { get; private set; }
        public IBaseRepository<QrmPerformance> QrmPerformance { get; private set; }
        public IBaseRepository<QrmTeam> QrmTeam { get; private set; }
        public IBaseRepository<QrmHeader> QrmHeader { get; private set; }
        public IBaseRepository<Statues> Statues { get; private set; }

        public IBaseRepository<TeamMembers> TeamMembers { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            User = new BaseRepository<User>(_context);
            Sections = new BaseRepository<Sections>(_context);
            Department = new BaseRepository<Department>(_context);
            KaizenCardHeader = new BaseRepository<KaizenCardHeader>(_context);
            UnitArea = new BaseRepository<UnitArea>(_context);
            Page = new BaseRepository<Page>(_context);
            PageLocalization = new BaseRepository<PageLocalization>(_context);
            PageAction = new BaseRepository<PageAction>(_context);
            KaizenCardDetails = new  BaseRepository<KaizenCardDetails>(_context);
            KaizenCardIssuerDetails = new BaseRepository<KaizenCardIssuerDetails>(_context);
            Currency = new BaseRepository<Currency>(_context);
            ImpoventAreaType = new BaseRepository<ImpoventAreaType>(_context);
            User = new BaseRepository<User>(_context);
            A3Header = new BaseRepository<A3header>(_context);
            ActionsPlan = new BaseRepository<ActionsPlan>(_context);
            A3detail = new BaseRepository<A3details>(_context); 
            FinanceVertification = new BaseRepository<FinanceVertification>(_context);
            KaizenCardImprovment = new BaseRepository<KaizenCardImprovment>(_context);
            Statues = new BaseRepository<Statues>(_context);
            TeamMembers = new BaseRepository<TeamMembers>(_context);
            
            
            //Qrm
          
            QrmTeam = new BaseRepository<QrmTeam>(_context);
            QrmPerformance = new BaseRepository<QrmPerformance>(_context);
            QrmImprovment= new BaseRepository<QrmImprovment>(_context);
            QrmHeader = new BaseRepository<QrmHeader>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> Commit()
        {
            return _context.SaveChangesAsync();
        }

        

        public Task<bool> SaveChangesCommiRollBack()
        {
            bool returnValue = true ;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {                  
                    returnValue = false;
                    dbContextTransaction.Rollback();
                }
            }
            
            return Task.FromResult(returnValue);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
