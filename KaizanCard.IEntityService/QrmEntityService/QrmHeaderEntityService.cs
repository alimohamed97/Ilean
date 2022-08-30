using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Data.Entity.Entities.Qrm;
using IRepository.Data;
using Lean.Data.EntityService.Base;
using Lean.Data.IEntityService.EntityDTO.QrmDto;
using Lean.Data.IEntityService.IQrmEntityService;

using Resources;
using System;

using System.Threading.Tasks;

namespace Lean.Data.EntityService.QrmEntityService
{
     class QrmHeaderEntityService : BaseEntityService, IQrmHeaderEntityService
    {

        public QrmHeaderEntityService(IUnitOfWork unitOfWork, IMessageResourceReader messageResource) : base(unitOfWork, messageResource)
        {
        }

        public async Task<ActionResultDto> CreateQrmHeader(RequestDto<QrmHeaderDto> QrmHeaderDto)
        {
            var result = new ActionResultDto();


            QrmHeader QrmHeader = new QrmHeader()
            {

                QrmServiceNameId = QrmHeaderDto.RequestData.QrmHeaderId,
                QrmCategoreyServiceId = QrmHeaderDto.RequestData.QrmHeaderId,
                CreatedDate = DateTime.Now,
                DeleteStatus=0,
                CreatedByUserId=QrmHeaderDto.RequestData.QrmHeaderId,

            };

            

            UnitOfWork.QrmHeader.Add(QrmHeader);

            if (await UnitOfWork.Commit() > default(int))
            {
                result.SetResult(true, MessageResource.DataAddededSuccessfully(QrmHeaderDto.Language));
            }
            else
            {
                result.SetResult(false, MessageResource.NotDataFound(QrmHeaderDto.Language));
            }

         
            return result;
        }


        public async Task<int> CreateQrmHeader(QrmHeader QrmHeaderDto)
        {


            QrmHeader QrmHeader = new QrmHeader()
            {
                QrmServiceNameId = QrmHeaderDto.QrmHeaderId,
                QrmCategoreyServiceId = QrmHeaderDto.QrmHeaderId,
                CreatedDate = DateTime.Now,
                DeleteStatus = 0,
                CreatedByUserId = QrmHeaderDto.QrmHeaderId,

            };



            UnitOfWork.QrmHeader.Add(QrmHeader);

            if (await UnitOfWork.Commit() > default(int))
            {
                return QrmHeader.QrmHeaderId;
            }

            return 0;
        }


    }



   
}
