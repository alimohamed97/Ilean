namespace Data.Auth.EntityService
{
    public class UserProfileUpdateDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public int OrgnizationId { get; set; }
        public long? UseravailabilityId { get; set; }

    }
}
