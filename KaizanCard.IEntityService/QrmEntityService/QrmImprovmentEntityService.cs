using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Core.Common.ExpCombiner;
using Core.Enum;
using Data.Entity.Entities.Qrm;
using IRepository.Data;
using Lean.Data.EntityService.Base;

using Lean.Data.IEntityService.EntityDTO.QrmDto;
using Lean.Data.IEntityService.IQrmEntityService;
using Repository.Data.DataContext;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Core.Enum.Common;

namespace Lean.Data.EntityService.QrmEntityService
{
    class QrmImprovmentEntityService : BaseEntityService, IQrmImprovmentEntityService
    {

        ApplicationDbContext AppContext { get; }

        IQrmHeaderEntityService QrmHeaderEntityService { get; }
        internal QrmImprovmentEntityService(IUnitOfWork unitOfWork, IMessageResourceReader messageResource) : base(unitOfWork, messageResource)
        {
        }

        public async Task<ActionResultDto> CreateQrmImprovments(RequestDto<QrmImprovmentDto> QrmImprovmentDto)
        {
            var Result = new ActionResultDto();

            QrmHeader QrmHeader = new QrmHeader()
            {
                CreatedByUserId = 1,
                CreatedDate = DateTime.Now,
                DeleteStatus = 0,
                QrmCategoreyServiceId = QrmImprovmentDto.RequestData.QrmCategoreyServiceId,
                QrmServiceNameId = (int)Qrm.QrmServiceName.Improvment,
            };


            int _QrmHeader = await QrmHeaderEntityService.CreateQrmHeader(QrmHeader);

            if (_QrmHeader > 0)
            {

                var QrmImporovment = new QrmImprovment()
                {
                    DownloadFile = QrmHeader.QrmCategoreyServiceId == (int)Qrm.QrmCategories.Virtual ? QrmImprovmentDto.RequestData.DownloadFile : "",
                    QrmHeaderId = _QrmHeader,
                    Description = QrmImprovmentDto.RequestData.Description,
                    Id = QrmImprovmentDto.RequestData.Id,
                    Name = QrmImprovmentDto.RequestData.Name,
                    UploadFile = QrmImprovmentDto.RequestData.UploadFile,

                };
                UnitOfWork.QrmImprovment.Add(QrmImporovment);

            }

            if (await UnitOfWork.Commit() > default(int))
            {
                Result.SetResult(true, MessageResource.DataAddededSuccessfully(QrmImprovmentDto.Language));
            }
            else
            {
                Result.SetResult(false, MessageResource.NotDataFound(QrmImprovmentDto.Language));
            }

            return Result;

        }

        public async Task<ActionResultDto> DeleteQrmImprovment(RequestDto<IdentityDto<int>> _ideintity)
        {
            ActionResultDto result = new ActionResultDto();

            QrmHeader _QrmHeader = await UnitOfWork.QrmHeader.FirstOrDefaultAsync(a => a.QrmHeaderId == _ideintity.RequestData.Identity &&
            a.DeleteStatus == (byte)DeleteStatus.NotDeleted);

            _QrmHeader.DeleteStatus = (byte)DeleteStatus.Deleted;

            await UnitOfWork.QrmHeader.Update(_QrmHeader);

            if (await UnitOfWork.Commit() > default(int))
            {
                result.SetResult(true, MessageResource.DataDeletedSuccessfully(1));
            }
            else
            {
                result.SetResult(false, MessageResource.NotDataFound(1));
            }

            return result;
        }

        public async Task<PageList<ImprovmnetListDto>> GetAllImprovmentList(ImprovmentSearchDto filterationDto)
        { 
            var improvmentList= new PageList<ImprovmnetListDto>();
             
            Expression<Func<ImprovmnetListDto, bool>> _Experssion1 = null;
            Expression<Func<ImprovmnetListDto, bool>> _Experssion2 = null;
            Expression<Func<ImprovmnetListDto, bool>> filter = null;

            if (filterationDto.ImprovmentID > 0)
            {
                _Experssion1 = a => a.ImprovmentID == filterationDto.ImprovmentID;
            }

            if (filterationDto.Name.Length > 0)
            {
                _Experssion2 = a => a.Name == filterationDto.Name;
            }
            filter = ExpressionCombiner.And(_Experssion1, _Experssion2);
            var qury = (from QrmImprovment in AppContext.QrmImprovment
                       select
                       new ImprovmnetListDto()
                       {
                           ImprovmentID = QrmImprovment.ImprovmentID,
                           Name = QrmImprovment.Name,

                       }).Where(filter).ToList();
            if (qury.Count > 0)
            {

                improvmentList.SetResult(qury.Count, qury);
            }


            return await Task.FromResult(improvmentList);

        }

        public async Task<QrmImprovmentDto> GetQrmImprovmentByID(RequestDto<IdentityDto<int>> _identity)
        {
            var responseDto = new ResponseDto<QrmHeaderDto>(MessageResource.GeneralError(1));

            QrmHeader QrmHeader =
                await UnitOfWork.QrmHeader.FirstOrDefaultAsync(a => a.QrmHeaderId == _identity.RequestData.Identity);

            var _QrmImprovment = QrmHeader.QrmImprovment;

            QrmImprovmentDto QrmImprovmentDto = new QrmImprovmentDto
            {
                DownloadFile = QrmHeader.QrmCategoreyServiceId == (int)Qrm.QrmCategories.Virtual ? _QrmImprovment.DownloadFile : "",
                QrmHeaderId = QrmHeader.QrmHeaderId,
                Id = _QrmImprovment.Id,
                Description = _QrmImprovment.Description,
                Name = _QrmImprovment.Name,
                UploadFile = _QrmImprovment.UploadFile,

            };
            return QrmImprovmentDto;
        }

        public async Task<ActionResultDto> UpdateQrmImprovment(RequestDto<QrmImprovmentDto> QrmImprovmentDto)
        {
            var result = new ActionResultDto();

            QrmImprovment _QrmImprovment = UnitOfWork.QrmImprovment
                .GetWhere(a => a.ImprovmentID == QrmImprovmentDto.RequestData.QrmImprovmenId).FirstOrDefault();


            _QrmImprovment.Name = QrmImprovmentDto.RequestData.Name;
            _QrmImprovment.Description = QrmImprovmentDto.RequestData.Description;
            _QrmImprovment.DownloadFile = QrmImprovmentDto.RequestData.DownloadFile;
            _QrmImprovment.UploadFile = QrmImprovmentDto.RequestData.UploadFile;



            await UnitOfWork.QrmImprovment.Update(_QrmImprovment);

            await UnitOfWork.Commit();
            result.SetResult(true, MessageResource.DataAddededSuccessfully(0));

            return result;


        }
    }
}
