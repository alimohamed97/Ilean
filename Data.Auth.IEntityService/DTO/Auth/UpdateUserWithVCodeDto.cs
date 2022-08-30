using System;

namespace Data.Auth.EntityService.Dto
{
    public class UpdateUserWithVCodeDto
    {
        public string VerificationCode { get; set; }
        public string Email { get; set; }
        public DateTime VerificationCodeExpirationTime { get; set; }
    }
}
