namespace Data.Auth.EntityService.Dto.Privilege
{
    public class UserPagePrivilege
    {
        public bool UserCanView { get; set; }
        public bool UserCanAdd { get; set; }
        public bool UserCanEdit { get; set; }
        public bool UserCanDelete { get; set; }
    }
}
