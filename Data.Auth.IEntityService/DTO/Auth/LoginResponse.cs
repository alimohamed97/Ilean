namespace Data.Auth.EntityService.Dto
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? UserTypeId { get; set; }
        public string ImageUrl { get; set; }
        public string AuthToken { get; set; }
    }
}
