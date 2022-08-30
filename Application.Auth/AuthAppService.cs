using Application.Auth.Setting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Auth;
using Core.Common.Dto.Response;
using Core.Common.Dto.Request;
using Data.Auth.EntityService;
using Data.Auth.EntityService.Dto;
using Resources;

namespace Application.Auth.AppService
{
    internal class AuthAppService : BaseAppService, IAuthAppService
    {
        #region CTRS
        private IAuthEntityService AuthEntityService { get; }
        private IUserEntityService UserEntityService { get; }

        private AuthSetting Setting { get; }
        public AuthAppService(AuthSetting appSettings, IMessageResourceReader messageResource, 
            IAuthEntityService authEntityService,  IUserEntityService userEntityService) 
            : base(appSettings, messageResource)
        {
            AuthEntityService = authEntityService;
            UserEntityService = userEntityService;
            Setting = appSettings;
        }
        #endregion

  
        public async Task<ResponseDto<LoginResponse>> ValidateUserCredentials(RequestDto<LoginDto> loginDto)
        {
            ResponseDto<LoginResponse> responseDto = new ResponseDto<LoginResponse>(MessageResource.GeneralError(loginDto.Language));

            LoginResponse successLoginDto = await AuthEntityService.ValidateUserCredentials(loginDto.RequestData);

            if (successLoginDto != null)
            {
                responseDto.ReturnSuccess(successLoginDto);
            }
            else
            {
                responseDto.ReturnError(MessageResource.PassOrUserNotValid(loginDto.Language));
            }

            return responseDto;
        }

        public async Task<ResponseDto<SuccessVerifyUserDto>> VerifyUser(RequestDto<VerifyUserDto> requestDto)
        {
            ResponseDto<SuccessVerifyUserDto> responseDto = new ResponseDto<SuccessVerifyUserDto>(MessageResource.GeneralError(requestDto.Language));
            SuccessVerifyUserDto successVerifyUserDto = await AuthEntityService.VerifyUser(requestDto.RequestData.Email, requestDto.RequestData.VCode);
            if (successVerifyUserDto != null)
            {
                responseDto.ReturnSuccess(successVerifyUserDto);
            }

            return responseDto;
        }


        public async Task<ResponseDto<UserdDto>> GetUserProfile(int language, int userId)
        {
            ResponseDto<UserdDto> responseDto = new ResponseDto<UserdDto>(MessageResource.GeneralError(language));
            UserdDto userDto = await AuthEntityService.GetUserProfile(userId);
  
            if (userDto != null)
                responseDto.ReturnSuccess(userDto);
            else
                responseDto.ReturnError(MessageResource.NotDataFound(language));

            return responseDto;
        }

        
    }
}
