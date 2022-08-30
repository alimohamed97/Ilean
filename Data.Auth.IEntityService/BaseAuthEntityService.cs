

using IRepository.Data;
using Resources;

namespace Data.Auth.EntityService
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
