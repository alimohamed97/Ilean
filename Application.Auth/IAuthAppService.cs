
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Auth.EntityService.Dto;

namespace Application.Auth
{
   public interface IAuthAppService
    {
        Task<ResponseDto<LoginResponse>> ValidateUserCredentials(RequestDto<LoginDto> loginDto);
    }
}
