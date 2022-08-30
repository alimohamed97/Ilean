namespace Presentation.UploadFileAPI.Setting
{
    public class UploadSetting
    {
        public string ContentServerUrl { get; set; }
        public string SystemUploadPath { get; set; }
        public string UserProfileUploadPath { get; set; }
        public string LocalizationImageUploadPath { get; set; }
        public string OrganizationImageUploadPath { get; set; }
        public string AppImageUploadPath { get; set; }
        public string UploadApplicationAPKPath { get; set; }
        public string UploadApplicationIconPath { get; set; }
        public string UploadDeviceImagePath { get; set; }
        public string UploadModelImagePath { get; internal set; }
    }
}
