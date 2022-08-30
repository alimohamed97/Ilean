using Application.Auth;
using Data.Auth.EntityService;
using Data.Auth.EntityService.Dto.User;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using static Core.Enum.Common;

using IRepository.Data;
using Data.Entity.Entities;
using Resources;
using static Core.Enum.UserEnum;

namespace Data.Auth.EntityService.EntityService
{
    internal class UserEntityService : BaseAuthEntityService, IUserEntityService
    {
        #region CTRS
        public UserEntityService(IUnitOfWork unitOfWork, IMessageResourceReader message) :
            base(unitOfWork, message)
        {
        }
        #endregion

        public async Task<UserdDto> GetUserById(int userId)
        {
            UserdDto userDto = null;
            User user = null;
            user = await UnitOfWork.User.GetWhere(em => em.UserId == userId && 
            em.DeleteStatus == (byte)DeleteStatus.NotDeleted).FirstOrDefaultAsync();
            if (user != null)
            {
                userDto = MappingUserToUserDTO(user);
            }
            return userDto;

        }

        public async Task<bool> UpdateForgetPasswordData(int userId, string code, DateTime expiration)
        {
            #region Declare Retunrn Var with intial value 
            bool result = default;
            #endregion

            #region Getting User by id 
            User user = await UnitOfWork.User.FirstOrDefaultAsync(s => s.UserId == userId);
            #endregion
            if (user != null)
            {
                user.ForgetPasswordKey = code;
                user.ForgetPasswordKeyExpirationDate = expiration;

                await UnitOfWork.User.Update(user);
                result = await UnitOfWork.Commit() > default(int);
            }

            return result;
        }

        public async Task<UserDto> GetUserByMail(int languageId, string mail)
        {
            #region Declare Return Var with intial value 
            UserDto userDto = null;
            #endregion

            #region Getting User By Email
            User user = await UnitOfWork.User.FirstOrDefaultAsync(x => x.Email.Trim().ToLower().Equals(mail.Trim().ToLower())
                     && x.IsActive == (byte)UserActivationStatus.Active && x.DeleteStatus == (byte)DeleteStatus.NotDeleted);
            #endregion

            #region Mapping
            if (user != null)
                userDto = MapUser(user);
            #endregion

            return userDto;
        }

        public async Task<bool> UpdateProfile(UserProfileUpdateDTO updateUserDto, int currentLoggedUser)
        {
            bool updated = default;
            User user = await UnitOfWork.User.GetWhere(em => em.UserId == currentLoggedUser && em.DeleteStatus == (byte)DeleteStatus.NotDeleted).FirstOrDefaultAsync();
            bool ItemIsExist = default(bool);
            ItemIsExist = await CheckIfExistForUpdateProfile(updateUserDto);
            if (user != null)
            {
                user = MapUserDtoToUserEntityProfile(user, updateUserDto);
                await UnitOfWork.User.Update(user);
                updated = await UnitOfWork.Commit() > default(int);
            }
            return updated;
        }

        #region Private Method

        private async Task<bool> CheckIfExistForUpdateProfile(UserProfileUpdateDTO userDto)
        {

            bool ItemIsExist = await UnitOfWork.User.GetAny(o => o.Email.ToLower().
            Trim().Contains(userDto.Email) && o.UserId != userDto.UserId);

            if (ItemIsExist)
                return false;
            else
                return true;

        }

        private UserdDto MappingUserToUserDTO(User user)
        {
            return new UserdDto
            {
                UserId = user.UserId,
                Email = user.Email,
               // FirstName = user.FirstName,
               // LastName = user.LastName,
    
                ImageUrl = user.UserImage,
                IsActive = user.IsActive,

                //UserTypeId = user.UserTypeId
            };
        }

        private UserDto MapUser(User user)
        {
            return new UserDto
            {
                UserId = user.UserId,
                FullName = user.UserName
            };
        }
        private User MapUserDtoToUserEntityProfile(User user, UserProfileUpdateDTO updateUserDto)
        {
       
            user.UserImage = updateUserDto.ImageUrl;
            user.Email = updateUserDto.Email;
            return user;
        }
        #endregion

    }
}
