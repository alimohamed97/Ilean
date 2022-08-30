using Data.Auth.EntityService.Dto;
using Data.Entity.Entities;
using IRepository.Data;
using Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Core.Enum.UserEnum;
using Microsoft.EntityFrameworkCore;
using Data.Auth.EntityService;
using Core.Common.Password;

namespace Data.Auth.EntityService
{
     class AuthEntityService : BaseAuthEntityService , IAuthEntityService
    {
        private IPasswordHelper PasswordHelper { get; }

        public AuthEntityService(IUnitOfWork unitOfWork, IPasswordHelper  _passwordHelper, IMessageResourceReader messageResource)
            :base(unitOfWork, messageResource)
        {
            PasswordHelper = _passwordHelper;
        }

        public Task<bool> CheckExpirationTime(DateTime now, string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserdDto> GetUserProfile(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailExist(string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPassword(ResetPasswordDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserVCode(UpdateUserWithVCodeDto updateUserWithVCodeDto)
        {
            throw new NotImplementedException();
        }

        private LoginResponse MapUserToUserDto(User user)
        {
            return new LoginResponse
            {
                FirstName = user.UserName,
                ImageUrl = user.UserImage,
                UserId = user.UserId,
                UserTypeId = 1
            };
        }

        public async Task<LoginResponse> ValidateUserCredentials(LoginDto requestData)
        {
            LoginResponse successLoginDto = null;

            User user = await UnitOfWork.User.GetWhere(em => em.Email.Trim().ToLower().Equals(requestData.UserMail.Trim().ToLower()) &&
             em.IsActive == (byte)UserActivationStatus.Active).FirstOrDefaultAsync();
            if (user != null)
            {
                if (PasswordHelper.ValidatePassword(requestData.Password, user.UserPasswordHash))
                {
                    successLoginDto = MapUserToUserDto(user);
                }
            }

            return successLoginDto;
        }

        public Task<SuccessVerifyUserDto> VerifyUser(string email, string vCode)
        {
            throw new NotImplementedException();
        }

        Task<UserdDto> IAuthEntityService.GetUserProfile(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
