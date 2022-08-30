using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lean.Data.EntityService.Base;
using Application.Auth;
using IRepository.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Common.Dto.Response;
using System.Linq.Expressions;
using Resources;
using Lean.Data.IEntityService.EntityDTO;
using Data.Entity.Entities;

namespace Lean.Data.IEntityService
{
   class KaizanCardEntityHeaderService : BaseEntityService, IKaizenCardHeadrEntityService
    {

        public KaizanCardEntityHeaderService(IUnitOfWork unitOfWork, IMessageResourceReader message)
             : base(unitOfWork, message)
        {

        }

        public async Task<ActionResultDto> CreateKarzianCardHeader(RequestDto<KaizenCardHeaderDto> karzianCardDto)
        {
            var result = new ActionResultDto();


            KaizenCardHeader kaizanCard = new KaizenCardHeader()
            {

                Number = karzianCardDto.RequestData.Number,
                Theme = karzianCardDto.RequestData.Theme,
                UnitAreaID = karzianCardDto.RequestData.UnitAreaID



            };



            UnitOfWork.KaizenCardHeader.Add(kaizanCard);

            if (await UnitOfWork.Commit() > default(int))
            {
                result.SetResult(true, MessageResource.DataAddededSuccessfully(karzianCardDto.Language));
            }
            else
            {
                result.SetResult(false, MessageResource.NotDataFound(karzianCardDto.Language));
            }

            return result;
        }


        public async Task<ActionResultDto> UpdateKaizanCardHeader(RequestDto<KaizenCardHeaderDto> kaizanCardDto)
        {
            KaizenCardHeader kaizanCardHeader = await UnitOfWork.KaizenCardHeader.FirstOrDefaultAsync(a => a.KaizanCardHeaderID == kaizanCardDto.RequestData.KaizanCardHeaderID);

            var result = new ActionResultDto();
            kaizanCardHeader = new KaizenCardHeader
            {
                KaizanCardHeaderID = kaizanCardDto.RequestData.KaizanCardHeaderID
            };
            var kaizanCardHeaderDto = new KaizenCardHeaderDto();
            kaizanCardHeader.KaizanCardHeaderID = kaizanCardDto.RequestData.KaizanCardHeaderID;
            kaizanCardHeader.Number = kaizanCardDto.RequestData.Number;
            kaizanCardHeader.Theme = kaizanCardDto.RequestData.Theme;

            await UnitOfWork.KaizenCardHeader.Update(kaizanCardHeader);

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



        public async Task<KaizenCardHeaderDto> GetKaizanCardHeaderByID(RequestDto<IdentityDto<int>> _identity)
        {
            var result = new ActionResultDto();

            KaizenCardHeader KaizenCardHeader = await UnitOfWork.KaizenCardHeader.FirstOrDefaultAsync(a => a.KaizanCardHeaderID == _identity.RequestData.Identity);

            KaizenCardHeaderDto _KaizenCardHeaderDto = new KaizenCardHeaderDto();

            _KaizenCardHeaderDto.KaizanCardHeaderID = KaizenCardHeader.KaizanCardHeaderID;

            return _KaizenCardHeaderDto;
        }





        public async void DeleteKaizanCard(RequestDto<KaizenCardHeaderDto> karzianCardDto)
        {
            KaizenCardHeader kaizanCardHeader = await UnitOfWork.KaizenCardHeader.FirstOrDefaultAsync(a => a.KaizanCardHeaderID == karzianCardDto.RequestData.KaizanCardHeaderID);
            if (kaizanCardHeader != null)
            {
                UnitOfWork.KaizenCardHeader.Delete(kaizanCardHeader);
                await UnitOfWork.Commit();


            }

        }

        public Task<ActionResultDto> DeleteKaizanCardHeader(RequestDto<KaizenCardHeaderDto> kaizanCardDto)
        {
            throw new NotImplementedException();
        }

        public async Task<PageList<KaizenCardHeaderDto>> GetAllKaizenCardHeaderList()
        {
            PageList<KaizenCardHeaderDto> pageList = new PageList<KaizenCardHeaderDto>();

            Expression<Func<KaizenCardHeader, bool>> filter = null;

            List<KaizenCardHeader> kaizenCardHeaderList = new List<KaizenCardHeader>();


            if (kaizenCardHeaderList?.Count > default(int))
            {
                List<KaizenCardHeaderDto> orgListDto = new List<KaizenCardHeaderDto>();
                foreach (KaizenCardHeader o in kaizenCardHeaderList)
                {
                    orgListDto.Add(new KaizenCardHeaderDto
                    {

                    });
                }

                pageList.SetResult(await UnitOfWork.KaizenCardHeader.GetCount(filter), orgListDto);
            }

            return pageList;

        }


    }
}
