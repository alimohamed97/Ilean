using Application.Auth;
using IRepository.Data;
using Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.EntityService.Base
{
   internal class BaseEntityService
    {
        #region Vars
        protected IUnitOfWork UnitOfWork { get; }
        protected IMessageResourceReader MessageResource { get; }
        #endregion

        internal BaseEntityService(IUnitOfWork unitOfWork, IMessageResourceReader messageResource)
        {
            UnitOfWork = unitOfWork;
            MessageResource = messageResource;
        }
    }
}
