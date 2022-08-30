namespace Data.Auth.EntityService.Dto.Privilege
{
    public class UserPagesDto
    {
        public int SystemPageId { get; set; }
        public string PageTitle { get; set; }
        public string PageLink { get; set; }
        public int? ParentPageId { get; set; }
        public int MenuOrder { get; set; }
        public string PageIcon { get; set; }
    }
}
