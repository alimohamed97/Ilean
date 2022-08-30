using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Dto.Action;
using IRepository.Data;
using Lean.Data.EntityService.Base;
using Lean.Data.IEntityService;
using Microsoft.EntityFrameworkCore;
using Resources;

namespace Lean.Data.EntityService
{
    internal class LookupEntityService : BaseEntityService , ILookupEntityService
    {
        public LookupEntityService(IUnitOfWork unitOfWork, IMessageResourceReader message)
            :base(unitOfWork, message)
        {

        }

        public async Task<List<DropDownItem<long>>> UnitAreaDropDownList()
        {
            var _UnitArea = await UnitOfWork.UnitArea.GetWhere().ToListAsync(); 

            return _UnitArea.Select(x => new DropDownItem<long>
            {
                Id = x.UnitAreaID,
                Name = x.UnitAreaName
            }).ToList();
            
        }

        public async Task<List<DropDownItem<long>>> SectionDropDownList()
        {
            var _Sections = await UnitOfWork.Sections.GetWhere().ToListAsync();

            return _Sections.Select(x => new DropDownItem<long>
            {
                Id = x.SectionID,
                Name = x.SectionName
            }).ToList();

        }
        public async Task<List<DropDownItem<long>>> DepartmentDropDownList()
        {
            var _Department = await UnitOfWork.Department.GetWhere().ToListAsync();

            return _Department.Select(x => new DropDownItem<long>
            {
                Id = x.DepartmentID,
                Name = x.DepartmentName
            }).ToList();

        }
        public async Task<List<DropDownItem<long>>> UsersDropDownList()
        {
            var _UnitArea = await UnitOfWork.User.GetWhere().ToListAsync();

            return _UnitArea.Select(x => new DropDownItem<long>
            {
                Id = x.UserId, Name = x.UserName
            }).ToList();
        }

        public async Task<List<DropDownItem<long>>> CurrencyDropDownList()
        {
            var _Curruncy = await UnitOfWork.Currency.GetWhere().ToListAsync();

            return _Curruncy.Select(x => new DropDownItem<long>
            {
                Id = x.CurrencyId,
                Name = x.CurrencyDesc
            }).ToList();
        }

        public async Task<List<DropDownItem<long>>> StatuesDropDownList()
        {
            var _Statues = await UnitOfWork.Statues.GetWhere().ToListAsync();

            return _Statues.Select(x => new DropDownItem<long>
            {
                Id = x.StatuesId,
                Name = x.StatuesName
            }).ToList();
        }

        public async Task<List<DropDownItem<long>>> ImpoventAreaTypeDropDownList()
        {
            var impoventAreaTypes = await UnitOfWork.ImpoventAreaType.GetWhere().ToListAsync();

            return impoventAreaTypes.Select(x => new DropDownItem<long>
            {
                Id = x.ImoprovmentID,
                Name = x.Title
            }).ToList();
        }

        public async Task<List<DropDownItem<long>>> TeamCoachDropDownList()
        {
            var _TeamCoachUser = await UnitOfWork.User.GetWhere().ToListAsync();

            return _TeamCoachUser.Select(x => new DropDownItem<long>
            {
                Id = x.UserId,
                Name = x.UserName
            }).ToList();
        }

        public async Task<List<DropDownItem<long>>> FinanceVertificationStatues()
        {
            var _FinanceVertification = await UnitOfWork.FinanceVertification.GetWhere().ToListAsync();
            return _FinanceVertification.Select(x => new DropDownItem<long>
            {
                Id = x.FinanceVertificationID,
                Name = x.Name
            }).ToList();
        }

        public async Task<List<DropDownItem<long>>> TeamMeambersDropDownList()
        {
            var _FinanceVertification = await UnitOfWork.TeamMembers.GetWhere().ToListAsync();
            return _FinanceVertification.Select(x => new DropDownItem<long>
            {
                Id = x.UserId,
                Name = x.User.UserName
            }).ToList();
        }
    }
}
