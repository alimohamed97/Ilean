using System;
using System.Threading.Tasks;
using Data.Auth.EntityService;
using Data.Auth.EntityService.Dto;

namespace Data.Auth.EntityService
{
    public interface IAuthEntityService
    {
        Task<LoginResponse> ValidateUserCredentials(LoginDto requestData);
        Task<bool> IsEmailExist(string userEmail);
        Task<bool> UpdateUserVCode(UpdateUserWithVCodeDto updateUserWithVCodeDto);
        Task<SuccessVerifyUserDto> VerifyUser(string email, string vCode);
        Task<bool> ResetPassword(ResetPasswordDto requestDto);
        Task<bool> CheckExpirationTime(DateTime now, string email);
        Task<UserdDto> GetUserProfile(int userId);
    }
}
