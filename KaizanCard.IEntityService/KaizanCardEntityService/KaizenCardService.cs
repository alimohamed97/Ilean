using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using IRepository.Data;
using Lean.Data.EntityService.Base;
using Lean.Data.IEntityService;
using Lean.Data.IEntityService.DTO;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Repository.Data.DataContext;
using Core.Common.ExpCombiner;
using static Core.Enum.Common;
using Data.Entity.Entities;
using Lean.Data.IEntityService.EntityDTO;

namespace Lean.Data.EntityService
{
    internal class KaizenCardService : BaseEntityService, IKaizenCardService
    {

        IKaizenCardHeadrEntityService KaizanCardHeaderEntityService { get; }

        ApplicationDbContext AppContext { get; }
        IKaizanCardEntityDetailService KaizanCardEntityDetailService { get; }
        public KaizenCardService(IKaizenCardHeadrEntityService _KaizanCardHeaderEntityService, IUnitOfWork unitOfWork, IMessageResourceReader message, ApplicationDbContext _context) : base(unitOfWork, message)
        {
            KaizanCardHeaderEntityService = _KaizanCardHeaderEntityService;

            AppContext = _context;
        }

        public async Task<ActionResultDto> DeleteKaizanCard(RequestDto<IdentityDto<int>> _identity)
        {
            ActionResultDto result = new ActionResultDto();

            KaizenCardHeader _KaizenCardHeader = await UnitOfWork.KaizenCardHeader.FirstOrDefaultAsync(a => a.KaizanCardHeaderID == _identity.RequestData.Identity &&
            a.DeleteStatus == (byte)DeleteStatus.NotDeleted);

            _KaizenCardHeader.DeleteStatus = (byte)DeleteStatus.Deleted;

            await UnitOfWork.KaizenCardHeader.Update(_KaizenCardHeader);

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


        public async Task<KaizenCardListDto> GetKaizanCardByID(RequestDto<IdentityDto<int>> _identity)
        {

            var responseDto = new ResponseDto<KaizenCardListDto>(MessageResource.GeneralError(1));

            KaizenCardHeader kaizenCardHeader =
                await UnitOfWork.KaizenCardHeader.FirstOrDefaultAsync(a => a.KaizanCardHeaderID == _identity.RequestData.Identity);

            if (kaizenCardHeader == null)
            {
                responseDto = new ResponseDto<KaizenCardListDto>(MessageResource.GeneralError(2));
                return null;
            }

            string TypeidKaizenCardimprovment = "";

            var _KaizenCardDetails = kaizenCardHeader.KaizenCardDetails.FirstOrDefault();
            var _KaizenCardIssuerDetails = kaizenCardHeader.KaizenCardIssuerDetails.FirstOrDefault();
            var _user = await UnitOfWork.User.FirstOrDefaultAsync(a => a.StuffNumber == _KaizenCardIssuerDetails.StuffNumber);
            var _KaizenCardImprovment = kaizenCardHeader.KaizenCardImprovment.ToList();

            kaizenCardHeader.KaizenCardImprovment.ToList().ForEach(d => TypeidKaizenCardimprovment += d.ImprovmentID.ToString() + ',');


            KaizenCardListDto kaizenCardDto = new KaizenCardListDto
            {

                KaizanCardHeaderID = kaizenCardHeader.KaizanCardHeaderID,
                Number = kaizenCardHeader.Number.ToString(),
                AfterUploadFileName = _KaizenCardDetails.AfterUploadFileName,
                BeforUploadFileName = _KaizenCardDetails.BeforUploadFileName,
                CauseOfProplem = _KaizenCardDetails.CauseOfProplem,

                ChampionUserID = _KaizenCardIssuerDetails.ChampionUserID,

                CostSavingDiscription = _KaizenCardDetails.CostSavingDiscription,
                CostSavingUploadFileName = _KaizenCardDetails.CostSavingUploadFileName,
                CountMeasuers = _KaizenCardDetails.CountMeasuers,

                CurrencyId = _KaizenCardDetails.CurrencyId,
                CurrencyDesc = _KaizenCardDetails.Currency.CurrencyDesc,

                DescriptionOfProplem = _KaizenCardDetails.DescriptionOfProplem,

                IssuedByUserId = _KaizenCardIssuerDetails.IssuedByUserId,
                IssuedByUserName = _KaizenCardIssuerDetails.User.UserName,

                ValidatedByUserID = _KaizenCardIssuerDetails.ValidatedByUserID,
                ValidatedByUserName = _KaizenCardIssuerDetails.ValidatedByUsers.UserName,


                issueddate = DateTime.Parse(_KaizenCardIssuerDetails.IssuedDate.ToString("dd/MM/yyyy")),

                KaizanCardIssuerDetailsID = _KaizenCardIssuerDetails.KaizanCardIssuerDetailsID,
                KaizenCardDetailsID = _KaizenCardDetails.KaizenCardDetailsID,
                KaizenCardimprovment = TypeidKaizenCardimprovment,
                ResultAndBenfits = _KaizenCardDetails.ResultAndBenfits,
                StatusId = _KaizenCardDetails.StatuesId,
                StuffNumber = _KaizenCardIssuerDetails.StuffNumber,
                Theme = kaizenCardHeader.Theme,
                TotalCostSaveingPervation = _KaizenCardDetails.TotalCostSaveingPervation.ToString(),
                UnitAreaID = kaizenCardHeader.UnitAreaID,

                ValidUntilDate = DateTime.Parse( _KaizenCardIssuerDetails.ValidUntilDate.ToString("dd/MM/yyyy")),
                Department = _user != null ? _user.Department.DepartmentName : "",
                Section = _user != null ? _user.Section.SectionName : "",
                UnitAreaTital = kaizenCardHeader.UnitAreaTital,
                TeamCoachId = _KaizenCardIssuerDetails.TeamCoachId,
                TeamCoachName = _KaizenCardIssuerDetails.TeamCoachUser.UserName,
                IsDraft = kaizenCardHeader.IsDraft,
                FinanceVertificationId = _KaizenCardDetails.FinanceVertificationId,
                FinanceVertificationName = _KaizenCardDetails.FinanceVertification.Name




            };

            return kaizenCardDto;
        }


        public async Task<ActionResultDto> CreateKarzianCard(RequestDto<KaizenCardDto> karzianCardDto)
        {

            var result = new ActionResultDto();

            var kaizanCardHeader = new KaizenCardHeader()
            {
                Number = int.Parse("0" + karzianCardDto.RequestData.Number),
                Theme = karzianCardDto.RequestData.Theme,
                UnitAreaID = karzianCardDto.RequestData.UnitAreaID,
                IsDraft = karzianCardDto.RequestData.IsDraft,
                DeleteStatus = 0,
                CreatedDate = DateTime.Now,
                UnitAreaTital = karzianCardDto.RequestData.UnitAreaTital,
                CreatedByUserID = karzianCardDto.UserId,
            };

            UnitOfWork.KaizenCardHeader.Add(kaizanCardHeader);

            List<string> KaizenCardimprovment = new List<string>();

            if (!String.IsNullOrEmpty(karzianCardDto.RequestData.KaizenCardimprovment))
            {

                KaizenCardimprovment = karzianCardDto.RequestData.KaizenCardimprovment.Remove(
                   karzianCardDto.RequestData.KaizenCardimprovment.LastIndexOf(',')).Split(',').ToList();

                var _deleteKaizenCardImprovmentNotInList = UnitOfWork.KaizenCardImprovment.GetWhere(a => !KaizenCardimprovment.Contains(a.ImprovmentID.ToString()));

                var _deleteResualt = UnitOfWork.KaizenCardImprovment.DeleteList(_deleteKaizenCardImprovmentNotInList.ToList());
            }
            await UnitOfWork.Commit();

            var KaizenCardDetails = new KaizenCardDetails()
            {
                AfterUploadFileName = karzianCardDto.RequestData.AfterUploadFileName,
                BeforUploadFileName = karzianCardDto.RequestData.BeforUploadFileName,
                CauseOfProplem = karzianCardDto.RequestData.CauseOfProplem,
                CostSavingDiscription = karzianCardDto.RequestData.CostSavingDiscription,
                CostSavingUploadFileName = karzianCardDto.RequestData.CostSavingUploadFileName,
                CountMeasuers = karzianCardDto.RequestData.CountMeasuers,
                DescriptionOfProplem = karzianCardDto.RequestData.DescriptionOfProplem,
                FinanceVerificationStatus = int.Parse("0" + karzianCardDto.RequestData.FinanceVerificationStatus),
                KaizanCardHeaderID = kaizanCardHeader.KaizanCardHeaderID,
                ResultAndBenfits = karzianCardDto.RequestData.ResultAndBenfits,
                TotalCostSaveingPervation = long.Parse("0" + karzianCardDto.RequestData.TotalCostSaveingPervation),
                CurrencyId = karzianCardDto.RequestData.CurrencyId,
                StatuesId = karzianCardDto.RequestData.StatusId,
                FinanceVertificationId = karzianCardDto.RequestData.FinanceVertificationId



            };


            var _KaizenCardIssuerDetails = new KaizenCardIssuerDetails()
            {
                ChampionUserID = karzianCardDto.RequestData.ChampionUserID,
                KaizanCardHeaderID = kaizanCardHeader.KaizanCardHeaderID,
                IssuedByUserId = karzianCardDto.RequestData.IssuedByUserId,
                ValidatedByUserID = karzianCardDto.RequestData.ValidatedByUserID,
                StuffNumber = int.Parse("0" + karzianCardDto.RequestData.StuffNumber),
                ValidUntilDate = DateTime.Parse(karzianCardDto.RequestData.ValidUntilDate),
                IssuedDate = DateTime.Parse(karzianCardDto.RequestData.issueddate),
                DepartmentID = 1,
                TeamCoachId = karzianCardDto.RequestData.TeamCoachId

            };


            var _KaizenCardImprovment = new List<KaizenCardImprovment>();

            foreach (var item in KaizenCardimprovment)
            {
                _KaizenCardImprovment.Add(new KaizenCardImprovment
                {
                    ImprovmentID = int.Parse(item),
                    KaizanCardHeaderID = kaizanCardHeader.KaizanCardHeaderID

                });


            }


            if (kaizanCardHeader.KaizanCardHeaderID > 0)
            {
                UnitOfWork.KaizenCardDetails.Add(KaizenCardDetails);
                UnitOfWork.KaizenCardIssuerDetails.Add(_KaizenCardIssuerDetails);
                await UnitOfWork.KaizenCardImprovment.AddRangeAsync(_KaizenCardImprovment);
            }

            await UnitOfWork.Commit();
            result.SetResult(true, MessageResource.DataAddededSuccessfully(0));

            return result;

        }

        public async Task<ActionResultDto> UpdateCreateKarzianCard(RequestDto<KaizenCardDto> karzianCardDto)
        {

            var result = new ActionResultDto();

            KaizenCardHeader _KaizenCardHeader = UnitOfWork.KaizenCardHeader
                .GetWhere(a => a.KaizanCardHeaderID == karzianCardDto.RequestData.KaizanCardHeaderID).FirstOrDefault();

            _KaizenCardHeader.Number = int.Parse("0" + karzianCardDto.RequestData.Number);
            _KaizenCardHeader.Theme = karzianCardDto.RequestData.Theme;
            _KaizenCardHeader.UnitAreaID = karzianCardDto.RequestData.UnitAreaID;
            _KaizenCardHeader.IsDraft = karzianCardDto.RequestData.IsDraft;
            _KaizenCardHeader.UnitAreaTital = karzianCardDto.RequestData.UnitAreaTital;

            await UnitOfWork.KaizenCardHeader.Update(_KaizenCardHeader);

            List<string> KaizenCardimprovment = new List<string>();

            if (!String.IsNullOrEmpty(karzianCardDto.RequestData.KaizenCardimprovment))
            {

                KaizenCardimprovment = karzianCardDto.RequestData.KaizenCardimprovment.Remove(
                   karzianCardDto.RequestData.KaizenCardimprovment.LastIndexOf(',')).Split(',').ToList();

                var _deleteKaizenCardImprovmentNotInList = UnitOfWork.KaizenCardImprovment.GetWhere(a => !KaizenCardimprovment.Contains(a.ImprovmentID.ToString()));

                var _deleteResualt = UnitOfWork.KaizenCardImprovment.DeleteList(_deleteKaizenCardImprovmentNotInList.ToList());
            }


            KaizenCardDetails _KaizenCardDetails = UnitOfWork.KaizenCardDetails
                .GetWhere(a => a.KaizanCardHeaderID == karzianCardDto.RequestData.KaizanCardHeaderID).FirstOrDefault();


            _KaizenCardDetails.AfterUploadFileName = karzianCardDto.RequestData.AfterUploadFileName;
            _KaizenCardDetails.BeforUploadFileName = karzianCardDto.RequestData.BeforUploadFileName;
            _KaizenCardDetails.CauseOfProplem = karzianCardDto.RequestData.CauseOfProplem;
            _KaizenCardDetails.CostSavingDiscription = karzianCardDto.RequestData.CostSavingDiscription;
            _KaizenCardDetails.CostSavingUploadFileName = karzianCardDto.RequestData.CostSavingUploadFileName;
            _KaizenCardDetails.CountMeasuers = karzianCardDto.RequestData.CountMeasuers;
            _KaizenCardDetails.DescriptionOfProplem = karzianCardDto.RequestData.DescriptionOfProplem;
            _KaizenCardDetails.FinanceVerificationStatus = int.Parse("0" + karzianCardDto.RequestData.FinanceVerificationStatus);
            _KaizenCardDetails.KaizanCardHeaderID = _KaizenCardHeader.KaizanCardHeaderID;
            _KaizenCardDetails.ResultAndBenfits = karzianCardDto.RequestData.ResultAndBenfits;
            _KaizenCardDetails.TotalCostSaveingPervation = int.Parse("0" + karzianCardDto.RequestData.TotalCostSaveingPervation);
            _KaizenCardDetails.CurrencyId = karzianCardDto.RequestData.CurrencyId;
            _KaizenCardDetails.StatuesId = karzianCardDto.RequestData.StatusId;


            KaizenCardIssuerDetails _KaizenCardIssuerDetails = UnitOfWork.KaizenCardIssuerDetails
            .GetWhere(a => a.KaizanCardHeaderID == karzianCardDto.RequestData.KaizanCardHeaderID).FirstOrDefault();


            _KaizenCardIssuerDetails.ChampionUserID = karzianCardDto.RequestData.ChampionUserID;
            _KaizenCardIssuerDetails.KaizanCardHeaderID = _KaizenCardHeader.KaizanCardHeaderID;
            _KaizenCardIssuerDetails.IssuedByUserId = karzianCardDto.RequestData.IssuedByUserId;
            _KaizenCardIssuerDetails.ValidatedByUserID = karzianCardDto.RequestData.ValidatedByUserID;
            _KaizenCardIssuerDetails.StuffNumber = int.Parse("0" + karzianCardDto.RequestData.StuffNumber);
            _KaizenCardIssuerDetails.ValidUntilDate = DateTime.Parse(karzianCardDto.RequestData.ValidUntilDate);
            _KaizenCardIssuerDetails.IssuedDate = DateTime.Parse(karzianCardDto.RequestData.issueddate);
            _KaizenCardIssuerDetails.DepartmentID = 1;



            var _KaizenCardImprovment = new List<KaizenCardImprovment>();

            foreach (var item in KaizenCardimprovment)
            {
                _KaizenCardImprovment.Add(new KaizenCardImprovment
                {
                    ImprovmentID = int.Parse(item),
                    KaizanCardHeaderID = _KaizenCardHeader.KaizanCardHeaderID

                });

            }




            if (_KaizenCardHeader.KaizanCardHeaderID > 0)
            {
                await UnitOfWork.KaizenCardDetails.Update(_KaizenCardDetails);
                await UnitOfWork.KaizenCardIssuerDetails.Update(_KaizenCardIssuerDetails);
                await UnitOfWork.KaizenCardImprovment.AddRangeAsync(_KaizenCardImprovment);

            }

            await UnitOfWork.Commit();
            result.SetResult(true, MessageResource.DataAddededSuccessfully(0));

            return result;

        }
        public async Task<PageList<KaizenCardListDto>> RetrieveAllKaizenCard(KaizenCardSearchDto filterationDto, string UrlParam)
        {

            var kaizenCardPageList = new PageList<KaizenCardListDto>();

            Expression<Func<KaizenCardListDto, bool>> _Experssion1 = null;
            Expression<Func<KaizenCardListDto, bool>> _Experssion2 = null;
            Expression<Func<KaizenCardListDto, bool>> filter = null;

            if (filterationDto.ChampionUserid > 0)
            {
                _Experssion1 = a => a.ChampionUserID == filterationDto.ChampionUserid;
            }

            if (filterationDto.IssuedbyUserid > 0)
            {
                _Experssion2 = a => a.IssuedByUserId == filterationDto.IssuedbyUserid;
            }

            filter = ExpressionCombiner.And(_Experssion1, _Experssion2);

            if (filterationDto.StuffNumber.Length > 0)
            {
                if (int.Parse("0" + filterationDto.StuffNumber) > 0)
                {
                    filter = ExpressionCombiner.And(filter, a => a.StuffNumber == int.Parse(filterationDto.StuffNumber));
                }

            }

            if (filterationDto.Theme.Length > 0)
            {
                filter = ExpressionCombiner.And(filter, a => a.Theme == filterationDto.Theme);
            }
            if (filterationDto.UnitAreaid > 0)
            {
                filter = ExpressionCombiner.And(filter, a => a.UnitAreaID == filterationDto.UnitAreaid);
            }
            if (filterationDto.SearchText != null)
            {
                if (filterationDto.SearchText.Length > 0)
                {
                    ;
                    int numericValue;
                    bool isNumber = int.TryParse(filterationDto.SearchText, out numericValue);
                    if (!isNumber)
                    {
                        filter = ExpressionCombiner.And(filter, a => a.Theme == filterationDto.SearchText);
                    }
                    else
                    {
                        filter = ExpressionCombiner.And(filter, a => a.StuffNumber == numericValue);
                    }

                }
            }

            if (filterationDto.StatuesId > 0)
            {
                filter = ExpressionCombiner.And(filter, a => a.StatuesId == filterationDto.StatuesId);
            }



            if (filterationDto.UnitAreaName.Length > 0)
            {
                filter = ExpressionCombiner.And(filter, a => a.UnitAreaTital.ToLower() == filterationDto.UnitAreaName.ToLower());
            }

            if (filterationDto.ValidUntildate  != null && filterationDto.ValidUntildate != "" )
            {
                var _ValidUntildate = DateTime.Parse(DateTime.Parse(filterationDto.ValidUntildate).ToString("dd-MM-yyyy"));

                filter = ExpressionCombiner.And(filter, a => a.ValidUntilDate == _ValidUntildate);
            }

            if (filterationDto.Issueddate != null && filterationDto.Issueddate != "")
            {
                var _Issueddate = DateTime.Parse(DateTime.Parse(filterationDto.Issueddate).ToString("dd-MM-yyyy"));

                filter = ExpressionCombiner.And(filter, a => a.issueddate == _Issueddate);
            }

            if (filter == null) filter = a => a.KaizanCardHeaderID > 0;

            filter = ExpressionCombiner.And(filter, a => a.DeleteStatus == 0);

            var query = (from header in AppContext.KaizenCardHeader
                        join details in AppContext.KaizenCardDetails
                        on header.KaizanCardHeaderID equals details.KaizanCardHeaderID
                        join issuer in AppContext.KaizenCardIssuerDetails on header.KaizanCardHeaderID equals
                        issuer.KaizanCardHeaderID
                        join user in AppContext.Users on issuer.StuffNumber equals user.StuffNumber
                        select new KaizenCardListDto()
                        {
                            KaizanCardHeaderID = header.KaizanCardHeaderID,
                            Serial = header.KaizanCardHeaderID.ToString(),
                            Theme = header.Theme,
                            StuffNumber = issuer.StuffNumber,
                            Issuedby = issuer.User.UserName,
                            IssuedByUserId = issuer.IssuedByUserId,
                            Department = issuer.User.Department.DepartmentName,
                            Section = user.Section.SectionName,
                            UnitAreaTital = header.UnitAreaTital,
                            ChampionUserID = issuer.ChampionUserID,
                            ChampionUserName = issuer.ChampionUsers.UserName,
                            CurrencyId = details.Currency.CurrencyId,
                            CurrencyName = details.Currency.CurrencyDesc,
                            StatuesId = details.StatuesId,
                            StatuesName = details.Statues.StatuesName,
                            DeleteStatus = header.DeleteStatus,
                            TeamCoachId = issuer.TeamCoachId,
                            TeamCoachName = issuer.TeamCoachUser.UserName,
                            AfterUploadFileNameUrl = UrlParam + details.AfterUploadFileName,
                            BeforUploadFileNameUrl = UrlParam + details.BeforUploadFileName,
                            AfterUploadFileName = details.AfterUploadFileName,
                            BeforUploadFileName = details.BeforUploadFileName,
                            FinanceVertificationId = details.FinanceVertificationId,
                            FinanceVertificationName = details.FinanceVertification.Name,
                            CreatorUserName = header.User.UserName,
                            ValidUntilDate = issuer.ValidUntilDate,
                            issueddate = issuer.IssuedDate

                        }).Where(filter).OrderBy(o=> o.KaizanCardHeaderID).ToList();




            if (query.Count > 0)
            {

                int totalcount = query.Count;

                int takeCount = filterationDto.PagingModel.PageSize;

                int skipCount = filterationDto.PagingModel.PageNumber;

                skipCount *= takeCount;

                if (skipCount <= 0)
                {
                    query = query.Take(takeCount).ToList();
                }
                else
                {
                    query = query.Skip(skipCount).Take(takeCount).ToList();
                }

                kaizenCardPageList.SetResult(totalcount, query);
            }

            return await Task.FromResult(kaizenCardPageList);

        }

        public async Task<PageList<KaizenCardListDto>>
            SearchKaizenCardByNameAndStuffNumber(RequestDto<IdentityDto<string>> _freetext)
        {

            var kaizenCardPageList = new PageList<KaizenCardListDto>();
            int numericValue;
            bool isNumber = int.TryParse(_freetext.RequestData.Identity, out numericValue);

            Expression<Func<KaizenCardListDto, bool>> filter = null;

            filter = a => a.Theme == _freetext.RequestData.Identity;

            if (isNumber) filter = a => a.StuffNumber == numericValue;

            if (_freetext.RequestData.Identity.Length <= 0) return null;

            var qury = (from header in AppContext.KaizenCardHeader
                        join details in AppContext.KaizenCardDetails
                    on header.KaizanCardHeaderID equals details.KaizanCardHeaderID
                        join issuer in AppContext.KaizenCardIssuerDetails on header.KaizanCardHeaderID equals
                        issuer.KaizanCardHeaderID
                        select new KaizenCardListDto()
                        {
                            Serial = header.KaizanCardHeaderID.ToString(),
                            Theme = header.Theme,
                            StuffNumber = issuer.StuffNumber,
                            Issuedby = issuer.User.UserName,
                            Department = issuer.User.Department.DepartmentName,
                            //UnitArea = header.UnitArea.UnitAreaName,
                            UnitAreaTital = header.UnitAreaTital,
                            ChampionUserID = issuer.ChampionUserID,
                            IssuedByUserId = issuer.IssuedByUserId,
                            UnitAreaID = header.UnitAreaID,
                            CurrencyId = details.Currency.CurrencyId,
                            CurrencyName = details.Currency.CurrencyDesc,
                            StatuesId = details.StatuesId,
                            StatuesName = details.Statues.StatuesName
                        }).Where(filter).ToList();


            if (qury.Count > 0) kaizenCardPageList.SetResult(qury.Count, qury);

            return await Task.FromResult(kaizenCardPageList);


            //  return kaizenCardPageList;

        }


    }
}
