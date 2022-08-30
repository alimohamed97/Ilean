using Lean.Data.IEntityService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using Resources;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using System.Threading.Tasks;
using Core.Common.Dto.Action;
using System.Linq.Expressions;
using Application.IBackEnd;
using Lean.Data.IEntityService.EntityDTO;

namespace Application.BackEnd.Applications
{
    internal class KaizenCardDetailAppService:BaseAppService, IKaizanCardDetailAppService
    {
       IKaizanCardEntityDetailService KaizanCardEntityDetailService { get; }
       IMessageResourceReader IMessageResourceReader { get; }
        public KaizenCardDetailAppService(IKaizanCardEntityDetailService _IKaizanCardEntityDetailService, BackEndSetting appSettings ,IMessageResourceReader messageResource) : base(appSettings, messageResource)
        {
            KaizanCardEntityDetailService = _IKaizanCardEntityDetailService;
            IMessageResourceReader = messageResource;
        }
        public async Task<ResponseDto<EmptyResponseDto>> CreateKaizanCardDetail(RequestDto<KaizenCardDetailsDto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));

            string message = Validate(request);

            if (string.IsNullOrWhiteSpace(message))
            {
                responseDto.ReturnStatus(new EmptyResponseDto(), await KaizanCardEntityDetailService.CreateKaizanCardDetail(request));
            }
            else
            {
                responseDto.ReturnError(message);
            }

            return responseDto;
        }
        public async Task<ResponseDto<EmptyResponseDto>> UpdateKaizanCardDetail(RequestDto<KaizenCardDetailsDto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));
            string message = Validate(request);
            if (string.IsNullOrWhiteSpace(message))
            {
                responseDto.ReturnStatus(new EmptyResponseDto(), await KaizanCardEntityDetailService.UpdateKaizanCardDetail(request));
            }
            else
            {
                responseDto.ReturnError(message);
            }

            return responseDto;
        }
        public async Task<ResponseDto<EmptyResponseDto>> DeleteOraganization(RequestDto<KaizenCardDetailsDto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));
            responseDto.ReturnStatus(new EmptyResponseDto(), await KaizanCardEntityDetailService.DeleteKaizanCardDetail(request));

            return responseDto;
        }  
        public async Task<ResponseDto<KaizenCardDetailsDto>> KaizanCardDetailById(RequestDto<IdentityDto<int>> request)
        {
            ResponseDto<KaizenCardDetailsDto> responseDto = new ResponseDto<KaizenCardDetailsDto>(MessageResource.GeneralError(request.Language));
            KaizenCardDetailsDto KaizenCardDetailsDto = await KaizanCardEntityDetailService.GetKaizanCardDetailByID(request);
            if (KaizenCardDetailsDto != null)
            {
                responseDto.ReturnSuccess(KaizenCardDetailsDto);
            }
            else
            {
                responseDto.ReturnError(MessageResource.NotDataFound(request.Language));
            }
            return responseDto;
        }

        private string Validate(RequestDto<KaizenCardDetailsDto> request)
        {
            return "Valid";
        }
    }
}
