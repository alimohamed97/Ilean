using IRepository.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Entity.Entities;
using Data.Entity.Entities.Qrm;
using Data.Entity.Entities.KaizenCard;

namespace IRepository.Data
{
    public  interface IUnitOfWork : IDisposable
    {
        //A3Project
        IBaseRepository<A3details> A3detail { get; }
        IBaseRepository<A3header> A3Header { get; }   
        IBaseRepository<ActionsPlan> ActionsPlan { get; }
        //Qrm
        IBaseRepository<QrmImprovment> QrmImprovment { get; }
        IBaseRepository<QrmPerformance> QrmPerformance { get; }
        IBaseRepository<QrmTeam> QrmTeam { get; }
        IBaseRepository<QrmHeader> QrmHeader { get; }
        IBaseRepository<User> User { get; }

        //KaizenCard
        IBaseRepository<KaizenCardHeader> KaizenCardHeader { get; }
        IBaseRepository<KaizenCardDetails> KaizenCardDetails { get; }
        IBaseRepository<KaizenCardIssuerDetails> KaizenCardIssuerDetails { get; }
        IBaseRepository<KaizenCardImprovment> KaizenCardImprovment { get; }  
        IBaseRepository<FinanceVertification> FinanceVertification { get; }
        IBaseRepository<UnitArea> UnitArea { get; }
        IBaseRepository<Department> Department { get; }      

        //Paging
        IBaseRepository<PageLocalization> PageLocalization { get; }
        IBaseRepository<Page> Page { get; }
        IBaseRepository<PageAction> PageAction { get; }
        IBaseRepository<ImpoventAreaType> ImpoventAreaType { get; }
        IBaseRepository<Sections> Sections { get; }
        IBaseRepository<Currency> Currency { get; }
        IBaseRepository<Statues> Statues { get; }
        IBaseRepository<TeamMembers> TeamMembers { get; }

        int Complete();
        Task<bool> SaveChangesCommiRollBack();
        Task<int> Commit();
    }
}
