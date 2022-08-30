namespace Data.Auth.EntityService
{
    public class UserdDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string AuthToken { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }
        public byte IsActive { get; set; }
        public int OrgnizationId { get; set; }
        public string OrgnizationName { get; set; }
        public long? UserTypeId { get; set; }
    }
}
