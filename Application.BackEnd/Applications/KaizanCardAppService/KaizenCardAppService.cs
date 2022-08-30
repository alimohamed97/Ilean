using Application.IBackEnd;
using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService;
using Lean.Data.IEntityService.DTO;
using Lean.Data.IEntityService.EntityDTO;
using Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Core.Enum.UploadEnum;

namespace Application.BackEnd.Applications
{
    internal class KaizenCardAppService:BaseAppService, IKaizenCardAppService
    {
        IKaizenCardService KaizenCardService { get; }
        public KaizenCardAppService(BackEndSetting appSettings, 
         IMessageResourceReader messageResource, IKaizenCardService _KaizenCardService):base(appSettings,messageResource)
        {
            KaizenCardService = _KaizenCardService;
        }

        public async Task<ResponseDto<EmptyResponseDto>> DeleteKaizanCard(RequestDto<IdentityDto<int>> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));
            responseDto.ReturnStatus(new EmptyResponseDto(), await KaizenCardService.DeleteKaizanCard(request));

            return responseDto;
        }

        public async Task<ResponseDto<KaizenCardListDto>> GetKaizenCardDtoById(RequestDto<IdentityDto<int>> request)
        {
            ResponseDto<KaizenCardListDto> responseDto = new ResponseDto<KaizenCardListDto>(MessageResource.GeneralError(1));
            KaizenCardListDto kaizenCardHeader  = await KaizenCardService.GetKaizanCardByID(request);

            

            if (kaizenCardHeader != null)
            {
                responseDto.ReturnSuccess(kaizenCardHeader);
                kaizenCardHeader.AfterUploadFileNameUrl =
                AppSettings.ContentServerUrl + (int)UploadFileType.OrganizationImage + "/" + kaizenCardHeader.AfterUploadFileName;
                kaizenCardHeader.BeforUploadFileNameUrl =
                AppSettings.ContentServerUrl + (int)UploadFileType.OrganizationImage + "/" + kaizenCardHeader.BeforUploadFileName;
            }
            else
            {
                responseDto.ReturnError(MessageResource.NotDataFound(request.Language));
            }
            return responseDto;
        }

        public async Task<ResponseDto<EmptyResponseDto>> UpdateKarzianCard(RequestDto<KaizenCardDto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));

            string message = Validate(request);

            if (string.IsNullOrWhiteSpace(message))
            {
                responseDto.ReturnStatus(new EmptyResponseDto(), await KaizenCardService.UpdateCreateKarzianCard(request));
            }
            else
            {
                responseDto.ReturnError(message);
            }

            return responseDto;
        }
        public async Task<ResponseDto<EmptyResponseDto>> CreateKarzianCard(RequestDto<KaizenCardDto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));

            string message = Validate(request);

            if (string.IsNullOrWhiteSpace(message))
            {
                responseDto.ReturnStatus(new EmptyResponseDto(), await KaizenCardService.CreateKarzianCard(request));
            }
            else
            {
                responseDto.ReturnError(message);
            }

            return responseDto;
        }

        public async Task<ResponseDto<PageList<KaizenCardListDto>>> GetAllKaizenCard(RequestDto<KaizenCardSearchDto> request)
        {
            ResponseDto<PageList<KaizenCardListDto>> response = new ResponseDto<PageList<KaizenCardListDto>>
                (MessageResource.GeneralError(request.Language));

            string UrlParam = AppSettings.ContentServerUrl + (int)UploadFileType.OrganizationImage + "/";

            response.ReturnSuccess(await KaizenCardService.RetrieveAllKaizenCard(request.RequestData, UrlParam));

            return response;
        }

        public async Task<ResponseDto<PageList<KaizenCardListDto>>> SearchKaizenCardByNameAndStuffNumber(RequestDto<IdentityDto<string>> request)
        {
            ResponseDto<PageList<KaizenCardListDto>> response = new ResponseDto<PageList<KaizenCardListDto>>
                (MessageResource.GeneralError(request.Language));

            response.ReturnSuccess(await KaizenCardService.SearchKaizenCardByNameAndStuffNumber(request));

            return response;
        }

        private string Validate(RequestDto<KaizenCardDto> request)
        {
            return "";
        }
    }
}
