
using Application.IBackEnd;
using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService.EntityDTO;
using Lean.Data.IEntityService.IActionService;
using Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.BackEnd.Applications.A3AppService
{
    public class A3ActionsPlanAppService:BaseAppService, IActionplanAppService
    {
        IActionsPlanEntityService a3EntityActionService { get; }
        IMessageResourceReader IMessageResourceReader { get; }

        public A3ActionsPlanAppService(IActionsPlanEntityService _a3EntityActionServicee, BackEndSetting appSettings, IMessageResourceReader messageResource) : base(appSettings, messageResource)
        {
            a3EntityActionService = _a3EntityActionServicee;
            IMessageResourceReader = messageResource;
        }


        private string Validate(RequestDto<A3ActionsPlanDto> request)
        {
            return "";
        }

        public async Task<ResponseDto<EmptyResponseDto>> CreateActionsPlan(RequestDto<A3ActionsPlanDto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));

            string message = Validate(request);

            if (string.IsNullOrWhiteSpace(message))
            {
                responseDto.ReturnStatus(new EmptyResponseDto(), await a3EntityActionService.CreateActionsPlan(request));
            }
            else
            {
                responseDto.ReturnError(message);
            }

            return responseDto;
        }

        public async Task<ResponseDto<A3ActionsPlanDto>> GetActionsPlanByID(RequestDto<IdentityDto<int>> request)
        {
            ResponseDto<A3ActionsPlanDto> responseDto = new ResponseDto<A3ActionsPlanDto>(MessageResource.GeneralError(1));
            A3ActionsPlanDto A3Action = await a3EntityActionService.GetActionsPlanByID(request);

            if (A3Action != null)
            {
                responseDto.ReturnSuccess(A3Action);
               

            }
            else
            {
                responseDto.ReturnError(MessageResource.NotDataFound(request.Language));
            }
            return responseDto;
        }

        public async Task<ResponseDto<EmptyResponseDto>> UpdateActionsPlan(RequestDto<A3ActionsPlanDto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));

            string message = Validate(request);

            if (string.IsNullOrWhiteSpace(message))
            {
                responseDto.ReturnStatus(new EmptyResponseDto(), await a3EntityActionService.UpdateActionsPlan(request));
            }
            else
            {
                responseDto.ReturnError(message);
            }

            return responseDto;
        }

        public async Task<ResponseDto<EmptyResponseDto>> DeleteActionsPlan(RequestDto<IdentityDto<int>> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));
            responseDto.ReturnStatus(new EmptyResponseDto(), await a3EntityActionService.DeleteActionPlan(request));
            return responseDto;
        }

        
        public async Task<ResponseDto<PageList<A3ActionsPlanDtoList>>> GetAllActionsPlan(RequestDto<IdentityDto<int>> request)
        {
            ResponseDto<PageList<A3ActionsPlanDtoList>> response = new ResponseDto<PageList<A3ActionsPlanDtoList>>
                (MessageResource.GeneralError(request.Language));

            response.ReturnSuccess(await a3EntityActionService.GetAllActionsPlan(request));

            return response;
        }
    }
    
}
    

