using Application.Auth;
using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Data.Entity.Entities;
using IRepository.Data;
using Lean.Data.EntityService.Base;
using Lean.Data.IEntityService;
using Lean.Data.IEntityService.EntityDTO;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Data.EntityService
{
    internal class KaizenCardEntityDetailService : BaseEntityService, IKaizanCardEntityDetailService
    {
        public KaizenCardEntityDetailService(IUnitOfWork unitOfWork, IMessageResourceReader messageResource) : base(unitOfWork, messageResource)
        {
        }

        public async Task<ActionResultDto> CreateKaizanCardDetail(RequestDto<KaizenCardDetailsDto> KaizanCardDetailsDto)
        {
            var result = new ActionResultDto();

            KaizenCardDetails kaizenCardDetails = new KaizenCardDetails()
            {
                KaizenCardDetailsID = KaizanCardDetailsDto.RequestData.KaizenCardDetailsID,
                AfterUploadFileName = KaizanCardDetailsDto.RequestData.AfterUploadFileName,
                BeforUploadFileName = KaizanCardDetailsDto.RequestData.BeforUploadFileName,
                CauseOfProplem = KaizanCardDetailsDto.RequestData.CauseOfProplem,
                TotalCostSaveingPervation = KaizanCardDetailsDto.RequestData.TotalCostSaveingPervation,
                ResultAndBenfits = KaizanCardDetailsDto.RequestData.ResultAndBenfits,
                CountMeasuers = KaizanCardDetailsDto.RequestData.CountMeasuers,
                DescriptionOfProplem = KaizanCardDetailsDto.RequestData.DescriptionOfProplem,
                CostSavingUploadFileName = KaizanCardDetailsDto.RequestData.CostSavingUploadFileName,
                CostSavingDiscription = KaizanCardDetailsDto.RequestData.CostSavingDiscription,




            };
            UnitOfWork.KaizenCardDetails.Add(kaizenCardDetails);


            if (await UnitOfWork.Commit() > default(int))
            {
                result.SetResult(true, MessageResource.DataAddededSuccessfully(KaizanCardDetailsDto.Language));
            }
            else
            {
                result.SetResult(false, MessageResource.NotDataFound(KaizanCardDetailsDto.Language));
            }

            return result;
        }

        public async Task<ActionResultDto> GetKaizanCardDetailByID(RequestDto<KaizenCardDetailsDto> KaizenCardDetailsDto)
        {
            var result = new ActionResultDto();
            KaizenCardDetails kaizenCardDetails = await UnitOfWork.KaizenCardDetails.FirstOrDefaultAsync(a => a.KaizenCardDetailsID == KaizenCardDetailsDto.RequestData.KaizenCardDetailsID);
            if (kaizenCardDetails != null)
            {
                UnitOfWork.KaizenCardDetails.Delete(kaizenCardDetails);
                await UnitOfWork.Commit();
            }
            if (await UnitOfWork.Commit() > default(int))
            {
                result.SetResult(true, MessageResource.DataAddededSuccessfully(1));
            }
            else
            {
                result.SetResult(false, MessageResource.NotDataFound(1));
            }

            return result;

        }

        public async Task<Core.Common.Dto.Response.PageList<KaizenCardDetailsDto>> GetAllKaizenCardDetailsList()
        {
            PageList<KaizenCardDetailsDto> pageList = new PageList<KaizenCardDetailsDto>();

            Expression<Func<KaizenCardDetails, bool>> filter = null;

            List<KaizenCardDetails> kaizenCardDetailsList = new List<KaizenCardDetails>();


            if (kaizenCardDetailsList?.Count > default(int))
            {
                List<KaizenCardDetailsDto> orgListDto = new List<KaizenCardDetailsDto>();
                foreach (KaizenCardDetails o in kaizenCardDetailsList)
                {
                    orgListDto.Add(new KaizenCardDetailsDto
                    {

                    });
                }

                pageList.SetResult(await UnitOfWork.KaizenCardDetails.GetCount(filter), orgListDto);
            }

            return pageList;
        }



        public async Task<KaizenCardDetailsDto> GetKaizanCardDetailByID(RequestDto<IdentityDto<int>> CardDetailsID)
        {

            KaizenCardDetails KaizenCardDetails = await UnitOfWork.KaizenCardDetails.FirstOrDefaultAsync(a => a.KaizenCardDetailsID == CardDetailsID.RequestData.Identity);

            KaizenCardDetailsDto kaizenCardDetailsDto = new KaizenCardDetailsDto
            {
                KaizenCardDetailsID = KaizenCardDetails.KaizenCardDetailsID,
                AfterUploadFileName = KaizenCardDetails.AfterUploadFileName,
                BeforUploadFileName = KaizenCardDetails.BeforUploadFileName,
                CauseOfProplem = KaizenCardDetails.CauseOfProplem,
                TotalCostSaveingPervation = KaizenCardDetails.TotalCostSaveingPervation,
                ResultAndBenfits = KaizenCardDetails.ResultAndBenfits,
                CountMeasuers = KaizenCardDetails.CountMeasuers,
                DescriptionOfProplem = KaizenCardDetails.DescriptionOfProplem,
                CostSavingUploadFileName = KaizenCardDetails.CostSavingUploadFileName,
                CostSavingDiscription = KaizenCardDetails.CostSavingDiscription,
            };

            return kaizenCardDetailsDto;
        }


        public async Task<ActionResultDto> UpdateKaizanCardDetail(RequestDto<KaizenCardDetailsDto> KaizenCardDetailsDto)
        {
            KaizenCardDetails KaizenCardDetails = await UnitOfWork.KaizenCardDetails.FirstOrDefaultAsync(a => a.KaizenCardDetailsID == KaizenCardDetailsDto.RequestData.KaizenCardDetailsID);

            var result = new ActionResultDto();
            KaizenCardDetails = new KaizenCardDetails
            {
                KaizenCardDetailsID = KaizenCardDetailsDto.RequestData.KaizenCardDetailsID,
            };
            var kaizenCardDetailsDto = new KaizenCardDetailsDto();


            KaizenCardDetails.KaizenCardDetailsID = KaizenCardDetailsDto.RequestData.KaizenCardDetailsID;
            KaizenCardDetails.AfterUploadFileName = KaizenCardDetailsDto.RequestData.AfterUploadFileName;
            KaizenCardDetails.BeforUploadFileName = KaizenCardDetailsDto.RequestData.BeforUploadFileName;
            KaizenCardDetails.CauseOfProplem = KaizenCardDetailsDto.RequestData.CauseOfProplem;
            KaizenCardDetails.TotalCostSaveingPervation = KaizenCardDetailsDto.RequestData.TotalCostSaveingPervation;
            KaizenCardDetails.ResultAndBenfits = KaizenCardDetailsDto.RequestData.ResultAndBenfits;
            KaizenCardDetails.CountMeasuers = KaizenCardDetailsDto.RequestData.CountMeasuers;
            KaizenCardDetails.DescriptionOfProplem = KaizenCardDetailsDto.RequestData.DescriptionOfProplem;
            KaizenCardDetails.CostSavingUploadFileName = KaizenCardDetailsDto.RequestData.CostSavingUploadFileName;
            KaizenCardDetails.CostSavingDiscription = KaizenCardDetailsDto.RequestData.CostSavingDiscription;

            await UnitOfWork.KaizenCardDetails.Update(KaizenCardDetails);

            if (await UnitOfWork.Commit() > default(int))
            {
                result.SetResult(true, MessageResource.DataAddededSuccessfully(1));
            }
            else
            {
                result.SetResult(false, MessageResource.NotDataFound(1));
            }

            return result;



        }

     
        public Task<ActionResultDto> DeleteKaizanCardDetail(RequestDto<KaizenCardDetailsDto> KaizenCardDetailsDto)
        {
            throw new NotImplementedException();
        }




    }
}
