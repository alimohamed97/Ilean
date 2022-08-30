using Application.IBackEnd;
using Core.Common.Dto.Action;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService;
using Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Application.BackEnd
{
    internal class AppLookupAppService : BaseAppService, IAppLookupAppService
    {
        ILookupEntityService ILookupEntityService { get; }
        public AppLookupAppService(ILookupEntityService _ILookupEntityService,
            BackEndSetting appSettings,
                                      IMessageResourceReader messageResource) :
            base(appSettings, messageResource)
        {
            ILookupEntityService = _ILookupEntityService;
        }

        public async Task<ResponseDto<List<DropDownItem<long>>>> DepartmentDropDownList()
        {
            ResponseDto<List<DropDownItem<long>>> responseDto = new ResponseDto<List<DropDownItem<long>>>((""));
            responseDto.ReturnSuccess(await ILookupEntityService.DepartmentDropDownList());

            return responseDto;
        }

        public async Task<ResponseDto<List<DropDownItem<long>>>> UnitAreaDropDownList()
        {
            ResponseDto<List<DropDownItem<long>>> responseDto = new ResponseDto<List<DropDownItem<long>>>((""));
            responseDto.ReturnSuccess(await ILookupEntityService.UnitAreaDropDownList());

            return responseDto;
        }

        public async Task<ResponseDto<List<DropDownItem<long>>>> SectionDropDownList()
        {
            ResponseDto<List<DropDownItem<long>>> responseDto = new ResponseDto<List<DropDownItem<long>>>((""));
            responseDto.ReturnSuccess(await ILookupEntityService.SectionDropDownList());

            return responseDto;
        }

        public async Task<ResponseDto<List<DropDownItem<long>>>> UsersDropDownList()
        {
            var responseDto = new ResponseDto<List<DropDownItem<long>>>((""));
            responseDto.ReturnSuccess(await ILookupEntityService.UsersDropDownList());

            return responseDto;

        }

        public async Task<ResponseDto<List<DropDownItem<long>>>> StatuesDropDownList()
        {
            ResponseDto<List<DropDownItem<long>>> responseDto = new ResponseDto<List<DropDownItem<long>>>((""));
            responseDto.ReturnSuccess(await ILookupEntityService.StatuesDropDownList());

            return responseDto;
        }
        public async Task<ResponseDto<List<DropDownItem<long>>>> CurrencyDropDownList()
        {
            var responseDto = new ResponseDto<List<DropDownItem<long>>>((""));
            responseDto.ReturnSuccess(await ILookupEntityService.CurrencyDropDownList());

            return responseDto;

        }

        public async Task<ResponseDto<List<DropDownItem<long>>>> ImpoventAreaTypeDropDownList()
        {
            var responseDto = new ResponseDto<List<DropDownItem<long>>>((""));
            responseDto.ReturnSuccess(await ILookupEntityService.ImpoventAreaTypeDropDownList());

            return responseDto;

        }

        public async Task<ResponseDto<List<DropDownItem<long>>>> TeamCoachDropDownList()
        {

            var responseDto = new ResponseDto<List<DropDownItem<long>>>((""));
            responseDto.ReturnSuccess(await ILookupEntityService.TeamCoachDropDownList());

            return responseDto;
        }

        public async Task<ResponseDto<List<DropDownItem<long>>>> FinanceVertificationStatues()
        {

            var responseDto = new ResponseDto<List<DropDownItem<long>>>((""));
            responseDto.ReturnSuccess(await ILookupEntityService.FinanceVertificationStatues());

            return responseDto;
        }

        public async Task<ResponseDto<List<DropDownItem<long>>>> TeamMeambersDropDownList()
        {

            var responseDto = new ResponseDto<List<DropDownItem<long>>>((""));
            responseDto.ReturnSuccess(await ILookupEntityService.TeamMeambersDropDownList());

            return responseDto;
        }
    }
}
