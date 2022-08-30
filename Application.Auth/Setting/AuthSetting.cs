namespace Application.Auth.Setting
{
    public class AuthSetting
    {
        public string Issuer { get; set; }
        public string SystemAudiance { get; set; }
        public string BackEndAudiance { get; set; }
        public string MobileAudiance { get; set; }
        public string ContentServerUrl { get; set; }

        public string ForgetPasswordUrl { get; set; }
        public int ForgetPasswordExpirationTime { get; set; }
        public string ForgetPasswordMailSubject { get; set; }
        public string ForgetPasswordFileName { get; set; }
        public string ForgetPasswordWebFileName { get; set; }
        public string EmailFilesPath { get; set; }
        public string MailHost { get; set; }
        public string SendMailUrl { get; set; }

    }
}
