using Core.Common.Dto.Action;
using Core.Common.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Application.IBackEnd
{
    public interface IAppLookupAppService
    {
        Task<ResponseDto<List<DropDownItem<long>>>> UnitAreaDropDownList();
        Task<ResponseDto<List<DropDownItem<long>>>> UsersDropDownList();
        Task<ResponseDto<List<DropDownItem<long>>>> StatuesDropDownList();
        Task<ResponseDto<List<DropDownItem<long>>>> CurrencyDropDownList();
        Task<ResponseDto<List<DropDownItem<long>>>> DepartmentDropDownList();
        Task<ResponseDto<List<DropDownItem<long>>>> SectionDropDownList();
        Task<ResponseDto<List<DropDownItem<long>>>> ImpoventAreaTypeDropDownList();
        Task<ResponseDto<List<DropDownItem<long>>>> TeamCoachDropDownList();

        Task<ResponseDto<List<DropDownItem<long>>>> FinanceVertificationStatues();
        Task<ResponseDto<List<DropDownItem<long>>>> TeamMeambersDropDownList();


    }
}
