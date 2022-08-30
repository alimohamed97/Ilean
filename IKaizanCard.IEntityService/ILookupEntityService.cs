using Core.Common.Dto.Action;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Lean.Data.IEntityService
{
    public interface ILookupEntityService
    {
        Task<List<DropDownItem<long>>> UnitAreaDropDownList();
        Task<List<DropDownItem<long>>> UsersDropDownList();
        Task<List<DropDownItem<long>>> CurrencyDropDownList();
        Task<List<DropDownItem<long>>> StatuesDropDownList();
        Task<List<DropDownItem<long>>> DepartmentDropDownList();
        Task<List<DropDownItem<long>>> SectionDropDownList();
        Task<List<DropDownItem<long>>> ImpoventAreaTypeDropDownList();
        Task<List<DropDownItem<long>>> TeamCoachDropDownList();
        Task<List<DropDownItem<long>>> FinanceVertificationStatues();

        Task<List<DropDownItem<long>>> TeamMeambersDropDownList();




    }
}
