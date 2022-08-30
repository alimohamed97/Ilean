using Data.Auth.EntityService.Dto.User;
using System;
using System.Threading.Tasks;
using Data.Auth.EntityService.Dto;

namespace Data.Auth.EntityService
{
    public interface IUserEntityService
    {
        Task<UserdDto> GetUserById(int UserId);
        Task<UserDto> GetUserByMail(int languageId, string mail);
        Task<bool> UpdateForgetPasswordData(int userId, string code, DateTime expiration);
        Task<bool> UpdateProfile(UserProfileUpdateDTO updateUserDto, int currentLoggedUserId);
    }
}
