using System.Text;
using System.Resources;
using Resources;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using System.Threading.Tasks;
using Core.Common.Dto.Action;
using System.Linq.Expressions;
using Lean.Data.IEntityService;
using System;
using Application.IBackEnd;
using Lean.Data.IEntityService.EntityDTO;

namespace Application.BackEnd.Applications
{
    public class KaizanCardHeaderAppService : BaseAppService , IKaizanCardHeaderAppService
    {
        IKaizenCardHeadrEntityService KaizanCardHeaderService { get; }
        IMessageResourceReader IMessageResourceReader { get; }

        public KaizanCardHeaderAppService(IKaizenCardHeadrEntityService _IKaizanCardEntityHeaderService, BackEndSetting appSettings, IMessageResourceReader messageResource) : base(appSettings, messageResource)
        {
            KaizanCardHeaderService = _IKaizanCardEntityHeaderService;
            IMessageResourceReader = messageResource;
        }
        public async Task<ResponseDto<EmptyResponseDto>> CreateKaizanCardHeader(RequestDto<KaizenCardHeaderDto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));

            string message = Validate(request);

            if (string.IsNullOrWhiteSpace(message))
            {
                responseDto.ReturnStatus(new EmptyResponseDto(), await KaizanCardHeaderService.CreateKarzianCardHeader(request));
            }
            else
            {
                responseDto.ReturnError(message);
            }

            return responseDto;
        }

        public async Task<ResponseDto<EmptyResponseDto>> UpdateKaizanCardHeader(RequestDto<KaizenCardHeaderDto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));
            string message = Validate(request);
            if (string.IsNullOrWhiteSpace(message))
            {
                responseDto.ReturnStatus(new EmptyResponseDto(), await KaizanCardHeaderService.UpdateKaizanCardHeader(request));
            }
            else
            {
                responseDto.ReturnError(message);
            }

            return responseDto;
        }

        public async Task<ResponseDto<EmptyResponseDto>> DeleteKaizenCardHeader(RequestDto<KaizenCardHeaderDto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));
            responseDto.ReturnStatus(new EmptyResponseDto(), await KaizanCardHeaderService.DeleteKaizanCardHeader(request));

            return responseDto;
        }

        public async Task<ResponseDto<KaizenCardHeaderDto>> GetKaizenCardHeaderById(RequestDto<IdentityDto<int>> request)
        {
            ResponseDto<KaizenCardHeaderDto> responseDto = new ResponseDto<KaizenCardHeaderDto>(MessageResource.GeneralError(request.Language));
            KaizenCardHeaderDto KaizenCardHeaderDto = await KaizanCardHeaderService.GetKaizanCardHeaderByID(request);
            if (KaizenCardHeaderDto != null)
            {
                responseDto.ReturnSuccess(KaizenCardHeaderDto);
            }
            else
            {
                responseDto.ReturnError(MessageResource.NotDataFound(request.Language));
            }
            return responseDto;
        }



       

        private string Validate(RequestDto<KaizenCardHeaderDto> request)
        {
            return "";
        }
    }
}
