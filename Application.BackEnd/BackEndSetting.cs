namespace Application.BackEnd
{
    public class BackEndSetting
    {
        public string ContentServerUrl { get; set; }
        public string UpdateDeviceFeatureSignalR { get;  set; }
        public string CreateDeviceFeatureSignalR { get;  set; }
        public string InsatllAPKSignalR { get;  set; }
        public string UnInsatllAPKSignalR { get;  set; }
        public string LockDeviceSignalR { get;  set; }
        public string UnlockDeviceSignalR { get;  set; }
        public string RebootDeviceSignalR { get;  set; }
        public string GetDeviceStatusUrl { get;  set; }

    }
}
