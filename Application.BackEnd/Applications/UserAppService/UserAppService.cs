using Application.IBackEnd.IUserAppService;
using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService.DTO;
using Lean.Data.IEntityService.IUsersEntityService;
using Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.BackEnd.Applications.UserAppService
{
    public class UserAppService:BaseAppService , IUserAppService
    {
        IUsersEntityService UsersEntityService { get; }
        IMessageResourceReader IMessageResourceReader { get; }

        public UserAppService(IUsersEntityService _IUsersEntityService, 
            BackEndSetting appSettings, IMessageResourceReader messageResource) 
            : base(appSettings, messageResource)
        {
            UsersEntityService = _IUsersEntityService;
            IMessageResourceReader = messageResource;
        }

        public async Task<ResponseDto<PageList<UserDto>>> GetAllUsers()
        {
            ResponseDto<PageList<UserDto>> response = new ResponseDto<PageList<UserDto>>
                (MessageResource.GeneralError(1));

            response.ReturnSuccess(await UsersEntityService.GetAllUserList());

            return response;
        }


        public async Task<ResponseDto<UserDto>> GetUserById(RequestDto<IdentityDto<int>> request)
        {
            ResponseDto<UserDto> responseDto = new ResponseDto<UserDto>(MessageResource.GeneralError(request.Language));
            
            UserDto UserDto = await UsersEntityService.GeUserByID(request);

            if (UserDto != null)
            {
                responseDto.ReturnSuccess(UserDto);
            }
            else
            {
                responseDto.ReturnError(MessageResource.NotDataFound(request.Language));
            }
            return responseDto;
        }

        public async Task<ResponseDto<UserDto>> GeUserByStuffNumber(RequestDto<IdentityDto<long>> request)
        {
            ResponseDto<UserDto> responseDto = new ResponseDto<UserDto>(MessageResource.GeneralError(request.Language));
            UserDto UserDto = await UsersEntityService.GeUserByStuffNumber(request);
            if (UserDto != null)
            {
                responseDto.ReturnSuccess(UserDto);
            }
            else
            {
                responseDto.ReturnError(MessageResource.NotDataFound(request.Language));
            }
            return responseDto;
        }
    }
}
