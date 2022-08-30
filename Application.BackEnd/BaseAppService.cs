
using Resources;

namespace Application.BackEnd
{

    public class BaseAppService
    {
        protected BackEndSetting AppSettings { get; }
        protected IMessageResourceReader MessageResource { get; }
        public BaseAppService(BackEndSetting appSettings, IMessageResourceReader messageResource)
        {
            AppSettings = appSettings;
            MessageResource = messageResource;
        }
    }
}
