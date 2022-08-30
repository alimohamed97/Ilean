using Application.IBackEnd;
using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService.DTO;
using Lean.Data.IEntityService.EntityDTO;
using Lean.Data.IEntityService.IA3EntityService;
using Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Core.Enum.UploadEnum;

namespace Application.BackEnd.Applications.A3AppService
{
    public class A3AppServices : BaseAppService, IA3AppService
    {
        IA3EntityService a3EntityService { get; }
        IMessageResourceReader IMessageResourceReader { get; }

        public A3AppServices(IA3EntityService _a3EntityService, BackEndSetting appSettings,
            IMessageResourceReader messageResource) : base(appSettings, messageResource)
        {
            a3EntityService = _a3EntityService;
            IMessageResourceReader = messageResource;
        }
        public async Task<ResponseDto<EmptyResponseDto>> CreateA32(RequestDto<A3SetDto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));

            string message = Validate();

            if (string.IsNullOrWhiteSpace(message))
            {
                responseDto.ReturnStatus(new EmptyResponseDto(), await a3EntityService.CreateA32(request));
            }
            else
            {
                responseDto.ReturnError(message);
            }

            return responseDto;
        }


        public async Task<ResponseDto<EmptyResponseDto>> CreateA3(RequestDto<A3Dto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));

            string message = Validate();

            if (string.IsNullOrWhiteSpace(message))
            {
                responseDto.ReturnStatus(new EmptyResponseDto(), await a3EntityService.CreateA3(request));
            }
            else
            {
                responseDto.ReturnError(message);
            }

            return responseDto;
        }

        public async Task<ResponseDto<EmptyResponseDto>> UpdateA3(RequestDto<A3Dto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));

            string message = Validate();

            if (string.IsNullOrWhiteSpace(message))
            {
                responseDto.ReturnStatus(new EmptyResponseDto(), await a3EntityService.UpdateA3(request));
            }
            else
            {
                responseDto.ReturnError(message);
            }

            return responseDto;
        }

        public async Task<ResponseDto<EmptyResponseDto>> UpdateUploadsFiles(RequestDto<UploadFileDto> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));

            string message = Validate();

            if (string.IsNullOrWhiteSpace(message))
            {
                responseDto.ReturnStatus(new EmptyResponseDto(), await a3EntityService.UpdateUploadsFiles(request));
            }
            else
            {
                responseDto.ReturnError(message);
            }

            return responseDto;
        }

        public async Task<ResponseDto<EmptyResponseDto>> DeleteA3(RequestDto<IdentityDto<int>> request)
        {
            ResponseDto<EmptyResponseDto> responseDto = new ResponseDto<EmptyResponseDto>(MessageResource.GeneralError(request.Language));
            responseDto.ReturnStatus(new EmptyResponseDto(), await a3EntityService.DeleteA3(request));
            return responseDto;
        }

        public async Task<ResponseDto<A3RowDto>> A3ById(RequestDto<IdentityDto<int>> request)
        {
            ResponseDto<A3RowDto> responseDto = new ResponseDto<A3RowDto>(MessageResource.GeneralError(1));
            A3RowDto A3Header = await a3EntityService.GetA3ByID(request);

            if (A3Header != null)
            {
                responseDto.ReturnSuccess(A3Header);
                //=========> please reminder to enhance this method ny creating object include all attrabu ====
                string _AssuranceUpload = A3Header.AssuranceUpload.Split("#")[0];
                A3Header.AssuranceUpload = A3Header.AssuranceUpload!= null && A3Header.AssuranceUpload.Length > 0 ?
                AppSettings.ContentServerUrl + (int)UploadFileType.OrganizationImage + "/" + A3Header.AssuranceUpload + "#" + _AssuranceUpload : "";

                string _BackgroundUpload = A3Header.BackgroundUpload.Split("#")[0];
                A3Header.BackgroundUpload = A3Header.BackgroundUpload != null && A3Header.BackgroundUpload.Length > 0 ?
                AppSettings.ContentServerUrl + (int)UploadFileType.OrganizationImage + "/" + A3Header.BackgroundUpload  + "#" + _BackgroundUpload : "";

                string _CurrentStateUpload = A3Header.CurrentStateUpload.Split("#")[0];
                A3Header.CurrentStateUpload = A3Header.CurrentStateUpload != null &&  A3Header.CurrentStateUpload.Length > 0 ?
                AppSettings.ContentServerUrl + (int)UploadFileType.OrganizationImage + "/" + A3Header.CurrentStateUpload + "#" + _CurrentStateUpload : "";

                string _FiveMiniteReviewUpload = A3Header.FiveMiniteReviewUpload.Split("#")[0];
                A3Header.FiveMiniteReviewUpload = A3Header.FiveMiniteReviewUpload != null && A3Header.FiveMiniteReviewUpload.Length> 0 ?
                AppSettings.ContentServerUrl + (int)UploadFileType.OrganizationImage + "/" + A3Header.FiveMiniteReviewUpload + "#" + _FiveMiniteReviewUpload : "";

                string _FutureStateUpload = A3Header.FutureStateUpload.Split("#")[0];
                A3Header.FutureStateUpload = A3Header.FutureStateUpload !=null && A3Header.FutureStateUpload.Length > 0 ?
                AppSettings.ContentServerUrl + (int)UploadFileType.OrganizationImage + "/" + A3Header.FutureStateUpload + "#" + A3Header.FutureStateUpload : "";

                string _StandardizationUpload = A3Header.StandardizationUpload.Split("#")[0];
                A3Header.StandardizationUpload = A3Header.StandardizationUpload != null && A3Header.StandardizationUpload.Length > 0 ?
                AppSettings.ContentServerUrl + (int)UploadFileType.OrganizationImage + "/" + A3Header.StandardizationUpload + "#" + A3Header.StandardizationUpload : "";

                string _AnalysisAndRootCauseRcupload = A3Header.AnalysisAndRootCauseRcupload.Split("#")[0];
                A3Header.AnalysisAndRootCauseRcupload = A3Header.AnalysisAndRootCauseRcupload != null && A3Header.AnalysisAndRootCauseRcupload.Length > 0 ?
               AppSettings.ContentServerUrl + (int)UploadFileType.OrganizationImage + "/" + A3Header.AnalysisAndRootCauseRcupload + "#" + _AnalysisAndRootCauseRcupload : "";

                string _CountermeasuresCmupload = A3Header.CountermeasuresCmupload.Split("#")[0];
                A3Header.CountermeasuresCmupload = A3Header.CountermeasuresCmupload != null && A3Header.CountermeasuresCmupload.Length > 0 ?
              AppSettings.ContentServerUrl + (int)UploadFileType.OrganizationImage + "/" + A3Header.CountermeasuresCmupload + "#" + _CountermeasuresCmupload : "";

            }
            else
            {
                responseDto.ReturnError(MessageResource.NotDataFound(request.Language));
            }
            return responseDto;
        }

        public async Task<ResponseDto<PageList<A3ListDto>>> GetAllA3(RequestDto<A3SearchDto> request)
        {
            ResponseDto<PageList<A3ListDto>> response = new ResponseDto<PageList<A3ListDto>>
                (MessageResource.GeneralError(request.Language));

            response.ReturnSuccess(await a3EntityService.GetAllA3(request.RequestData));

            return response;
        }

        private string Validate()
        {
            return "";
        }
    }
}