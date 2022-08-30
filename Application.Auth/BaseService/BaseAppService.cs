

using Resources;

namespace Application.Auth
{
    internal class BaseAppService
    {
        protected Setting.AuthSetting AppSettings { get; }
        protected IMessageResourceReader MessageResource { get; }
        internal BaseAppService(Setting.AuthSetting appSettings, IMessageResourceReader messageResource)
        {
            AppSettings = appSettings;
            MessageResource = messageResource;
        }
    }
}
