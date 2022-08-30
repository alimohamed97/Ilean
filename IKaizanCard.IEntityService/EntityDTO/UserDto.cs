
using System;
using System.Collections.Generic;

using System.Text;

namespace Lean.Data.IEntityService.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string StuffNo { get; set; }
        public string Email { get; set; }
        public int DepartmentID { get; set; }
        public int SectionID { get; set; }
        public string UserPasswordHash { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public string Mobile { get; set; }
        public string UserImage { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string RefreshToken { get; set; }
        public string ForgetPasswordKey { get; set; }
        public DateTime? ForgetPasswordKeyExpirationDate { get; set; }
        public byte IsActive { get; set; }


    }
}
