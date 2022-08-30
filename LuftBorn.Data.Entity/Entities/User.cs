using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Entities
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public long StuffNumber { get; set; }
        public string Email { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        [ForeignKey("Sections")]
        public int SectionID { get; set; }

        public string UserPasswordHash { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public string Mobile { get; set; }
        public string UserImage { get; set; }
        public string RefreshToken { get; set; }
        public long UserTypeId { get; set; }
        public int? RoleId { get; set; }
        public string ForgetPasswordKey { get; set; }
        public DateTime? ForgetPasswordKeyExpirationDate { get; set; }
        //public DateTime? CreatedDate { get; set; }
        public byte IsActive { get; set; }
        public virtual Department Department { get; set; }
        public virtual Sections Section { get; set; }


    }
}
