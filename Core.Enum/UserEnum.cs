namespace Core.Enum
{
    public class UserEnum
    {
        public enum UserType
        {
            SuperAdmin = 1,
            OrgnizationAdmin = 2,
            OrgnizationUser= 3,
            StoreAdmin = 4,
            NormalUser = 5,
        }

        public enum UserActivationStatus
        {
            Active = 90,
            InActive = 91
        }
    }
}
