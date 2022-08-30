


using IRepository.Data;
using Resources;

namespace Application.Auth
{
    internal class BaseAuthEntityService
    {
        #region Vars
        protected IUnitOfWork UnitOfWork { get; }
        protected IMessageResourceReader MessageResource { get; }
        #endregion

        internal BaseAuthEntityService(IUnitOfWork unitOfWork, IMessageResourceReader messageResource)
        {
            UnitOfWork = unitOfWork;
            MessageResource = messageResource;
        }
    }
}
