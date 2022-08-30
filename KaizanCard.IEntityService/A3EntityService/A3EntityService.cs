using Application.Auth;
using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Core.Common.ExpCombiner;
using Data.Entity.Entities;
using IRepository.Data;
using Lean.Data.EntityService.Base;
using Lean.Data.IEntityService.DTO;
using Lean.Data.IEntityService.EntityDTO;
using Lean.Data.IEntityService.IA3EntityService;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Repository.Data.DataContext;
using System.Text;
using System.Threading.Tasks;
using static Core.Enum.Common;
using Lean.Data.IEntityService.EntityDTO.A3;

namespace Lean.Data.EntityService.A3EntityService
{
    internal class A3EntityService : BaseEntityService, IA3EntityService
    {
        ApplicationDbContext AppContext { get; }
        public A3EntityService(IUnitOfWork unitOfWork,
            IMessageResourceReader messageResource, ApplicationDbContext _context)
            : base(unitOfWork, messageResource)
        {
         
            AppContext = _context;

        }
        public async Task<ActionResultDto> CreateA32(RequestDto<A3SetDto> A3SetDto)
        {
            var result = new ActionResultDto();
            if (await UnitOfWork.Commit() > default(int))
            {
                result.SetResult(true, MessageResource.DataAddededSuccessfully(A3SetDto.Language));
            }
            else
            {
                result.SetResult(false, MessageResource.NotDataFound(A3SetDto.Language));
            }

            return result;


        }


            public async Task<ActionResultDto> CreateA3(RequestDto<A3Dto> A3Dto)
        {
            var result = new ActionResultDto();
            A3header a3header = new A3header()
            {
                A3Number = A3Dto.RequestData.A3number,
                TeamCoachId = A3Dto.RequestData.TeamCoachId,
                TeamLeadUserId = A3Dto.RequestData.TeamLeadUserId,
                Title = A3Dto.RequestData.Title,
                Process = A3Dto.RequestData.Process,
                IssuedDate = A3Dto.RequestData.IssuedDate,
                IssuedByUserId = A3Dto.RequestData.IssuedByUserId,
                DeleteStatus = 0,
                StuffNumber = A3Dto.RequestData.StuffNumber,
                StatuesId = A3Dto.RequestData.StatuesId,
                CreatedDate = DateTime.Now

            };
            UnitOfWork.A3Header.Add(a3header);
            await UnitOfWork.Commit();

            if (a3header.A3headerId > 0)
            {
                A3details a3Detail = new A3details()
                {
                    A3headerId = a3header.A3headerId,
                    StandardizationDes = A3Dto.RequestData.StandardizationDes,
                    StandardizationUpload = A3Dto.RequestData.StandardizationUpload,
                    CountermeasuresCmdes = A3Dto.RequestData.CountermeasuresCmdes,
                    CountermeasuresCmupload = A3Dto.RequestData.CountermeasuresCmupload,
                    CurrentStateDes = A3Dto.RequestData.CurrentStateDes,
                    CurrentStateUpload = A3Dto.RequestData.CurrentStateUpload,
                    AnalysisAndRootCauseRcupload = A3Dto.RequestData.AnalysisAndRootCauseRcupload,
                    AnalysisAndRootCauseRcDes = A3Dto.RequestData.AnalysisAndRootCauseRcDes,

        
                    AssuranceUpload = A3Dto.RequestData.AssuranceUpload,
                    BackgroundDes = A3Dto.RequestData.BackgroundDes,
                    BackgroundUpload = A3Dto.RequestData.BackgroundUpload,
                    FutureStateDes = A3Dto.RequestData.FutureStateDes,
                    FutureStateUpload = A3Dto.RequestData.FutureStateUpload,
                    FiveMiniteReviewUpload = A3Dto.RequestData.FiveMiniteReviewUpload,
                   //AnalysisAndRootCauseDes=A3Dto.RequestData.AnalysisAndRootCauseDes,
                    FiveMiniteReviewDes = A3Dto.RequestData.FiveMiniteReviewDes

                };
                UnitOfWork.A3detail.Add(a3Detail);
                List<string> TeamMembers = new List<string>();

                if (!String.IsNullOrEmpty(A3Dto.RequestData.TeamMembers))
                {
                    if(A3Dto.RequestData.TeamMembers.LastIndexOf(",")  == A3Dto.RequestData.TeamMembers.Length -1)
                    {
                        TeamMembers = A3Dto.RequestData.TeamMembers.Remove(
                     A3Dto.RequestData.TeamMembers.LastIndexOf(',')).Split(',').ToList();
                    }
                    else
                    {
                        TeamMembers = A3Dto.RequestData.TeamMembers.Split(',').ToList();
                    }

                    var _deleteA3TeamMbersNotInList = UnitOfWork.TeamMembers.GetWhere(a => !TeamMembers.Contains(a.TeamMembersId.ToString())
                    && a.A3HeaderId == a3header.A3headerId).ToList();

                    var _deleteResualt = UnitOfWork.TeamMembers
                        .DeleteList(_deleteA3TeamMbersNotInList.ToList());

                    var _TeamMember = new List<TeamMembers>();

                    foreach (var item in TeamMembers)
                    {
                        _TeamMember.Add(new TeamMembers
                        {
                            A3HeaderId = a3header.A3headerId,
                            UserId = int.Parse(item)
                        });
                    }

                    await UnitOfWork.TeamMembers.AddRangeAsync(_TeamMember);
                }

            }

            if (await UnitOfWork.Commit() > default(int))
            {
                result.SetResult(true, MessageResource.DataAddededSuccessfully(A3Dto.Language), a3header.A3headerId);
            }
            else
            {
                result.SetResult(false, MessageResource.NotDataFound(A3Dto.Language));
            }

            return result;
        }
        public async Task<ActionResultDto> DeleteA3(RequestDto<IdentityDto<int>> _identity)
        {
            ActionResultDto result = new ActionResultDto();

            A3header _A3Header = await UnitOfWork.A3Header.FirstOrDefaultAsync(a => a.A3headerId == _identity.RequestData.Identity &&
            a.DeleteStatus == (byte)DeleteStatus.NotDeleted);

            _A3Header.DeleteStatus = (byte)DeleteStatus.Deleted;

            await UnitOfWork.A3Header.Update(_A3Header);

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
        public async Task<A3RowDto> GetA3ByID(RequestDto<IdentityDto<int>> A3ID)
        {
            var result = new A3RowDto();

            A3header a3Header = await UnitOfWork.A3Header.FirstOrDefaultAsync(a => a.A3headerId == A3ID.RequestData.Identity);
            
            TeamMembers team = await UnitOfWork.TeamMembers.FirstOrDefaultAsync(a => a.A3HeaderId == A3ID.RequestData.Identity);
          
            var _A3Details = a3Header.A3details.FirstOrDefault();
            var _A3Actionplan = a3Header.ActionsPlans.ToList();
            

            var _A3ActionsPlanDto = new List<A3ActionsPlanDtoList>();

            foreach (var item in _A3Actionplan)
            {
                _A3ActionsPlanDto.Add(new A3ActionsPlanDtoList
                {

                    Action = item.Action,
                    Name = item.User.UserName,
                    DueData = item.DueData,
                    ActionPlanStatuesID = item.ActionPlanStatuesID,
                    UserIdstuffNo = item.UserIdstuffNo,
                    A3headerId = item.A3headerId,
                    DeleteStatus = 0,
                    StuffNumber = item.User.StuffNumber,
                    StatuesName = item.ActionPlanStatues.ActionPlanStatuesTital,
                    ActionsPlanId = item.ActionsPlanId,

  
                });
            };
            
            var a3Dto = new A3RowDto
            {

                A3headerId = a3Header.A3headerId,
                IssuedByUserId = a3Header.IssuedByUserId,
                UserIdstuffNo = a3Header.StuffNumber,
                IssuedDate = a3Header.IssuedDate,
                A3number = a3Header.A3Number,
                TeamCoachId = a3Header.TeamCoachId,
                TeamLeadUserId = a3Header.TeamLeadUserId,
                Title = a3Header.Title,
                Process = a3Header.Process,
                StuffNumber = a3Header.StuffNumber,
                StatuesId = a3Header.StatuesId,

                A3detailId = _A3Details.A3detailId,
                StandardizationDes = _A3Details.StandardizationDes,
                AssuranceDes = _A3Details.AssuranceDes,             
                BackgroundDes = _A3Details.BackgroundDes,    
                CountermeasuresCmdes = _A3Details.CountermeasuresCmdes,
                CurrentStateDes = _A3Details.CurrentStateDes,
                FutureStateDes = _A3Details.FutureStateDes,
                CountermeasuresCmupload = _A3Details.CountermeasuresCmupload,
                AssuranceUpload = _A3Details.AssuranceUpload,
                AnalysisAndRootCauseRcupload = _A3Details.AnalysisAndRootCauseRcupload,
                AnalysisAndRootCauseRcDes = _A3Details.AnalysisAndRootCauseRcDes,

                FutureStateUpload = _A3Details.FutureStateUpload,
                BackgroundUpload = _A3Details.BackgroundUpload,
                FiveMiniteReviewUpload = _A3Details.FiveMiniteReviewUpload,
                StandardizationUpload = _A3Details.StandardizationUpload,
                CurrentStateUpload = _A3Details.CurrentStateUpload,
                FiveMiniteReviewDes = _A3Details.FiveMiniteReviewDes,
                
                A3ActionsPlanDto = _A3ActionsPlanDto,
                

            };

            return a3Dto;
        }
        public async Task<PageList<A3ListDto>> GetAllA3(A3SearchDto filterationDto)
        {
            var A3PageList = new PageList<A3ListDto>();
            Expression<Func<A3ListDto, bool>> _Experssion1 = null;
            Expression<Func<A3ListDto, bool>> _Experssion2 = null;
            Expression<Func<A3ListDto, bool>> filter = null ;

            if (filterationDto.TeamCoachId > 0)
            {
                _Experssion1 = a => a.TeamCoachId == filterationDto.TeamCoachId;
            }

            if (filterationDto.TeamLeadUserId > 0)
            {
                _Experssion2 = a => a.TeamLeadUserId == filterationDto.TeamLeadUserId;
            }

            if (filter == null) filter = a => a.DeleteStatus == 0;

            filter = ExpressionCombiner.And(_Experssion1, _Experssion2);

            if (filterationDto.Title != null) {
                if (filterationDto.Title.Length > 0)
                {
                    filter = ExpressionCombiner.And(filter, a => a.Title == filterationDto.Title);
                }
            }
            if (filterationDto.StatuesId > 0)
            {
                filter = ExpressionCombiner.And(filter, a => a.StatuesId == filterationDto.StatuesId);
            }
         
            if (filterationDto.A3Number > 0)
            {
                filter = ExpressionCombiner.And(filter, a => a.A3Number == filterationDto.A3Number);
            }
         
             filter = ExpressionCombiner.And(filter, a => a.DeleteStatus  == 0);

            var query = (from header in AppContext.A3header
                         join A3detail in AppContext.A3details on header.A3headerId equals
                         A3detail.A3headerId

                         select new A3ListDto()
                         {
                             A3headerId = header.A3headerId,
                             A3Number = header.A3headerId,
                             Process = header.Process,
                             StatuesName = header.Statues.StatuesName,
                             TeamLeadName = header.TeamLeadUser.UserName,
                             Title = header.Title,
                             TeamCoachName = header.TeamCoachUser.UserName,
                             TeamCoachId = header.TeamCoachId,
                             TeamLeadUserId = header.TeamLeadUserId,

                             DeleteStatus = header.DeleteStatus

                         }).Where(filter).OrderBy(a=> a.A3headerId).ToList();




            if (query.Count > 0)
            {
                int totalcount = query.Count;

                int takeCount = filterationDto.PagingModel.PageSize;

                int skipCount = filterationDto.PagingModel.PageNumber;

                skipCount *= takeCount;

                if (skipCount <= 0 )
                {
                    query = query.Take(takeCount).ToList();
                }
                else
                {
                    query = query.Skip(skipCount).Take(takeCount).ToList();
                }

                A3PageList.SetResult(totalcount, query);
            }
            return await Task.FromResult(A3PageList);


        }

        public async Task<ActionResultDto> UpdateUploadsFiles(RequestDto<UploadFileDto> _UploadFileDto)
        {
            var result = new ActionResultDto();

            if(_UploadFileDto.RequestData.A3headerId <= 0)
            {
                 result.SetResult(false, MessageResource.NotDataFound(1));
                return result ;
            }

            A3details a3Detail = UnitOfWork.A3detail.GetWhere(a => a.A3headerId 
            == _UploadFileDto.RequestData.A3headerId).FirstOrDefault();

            

            switch (_UploadFileDto.RequestData.UploadFlag)
            {
                case 6: a3Detail.AssuranceUpload = _UploadFileDto.RequestData.AssuranceUpload;
                    break;

                case 1:
                    a3Detail.BackgroundUpload = _UploadFileDto.RequestData.BackgroundUpload; 
                    break;

                case 3:
                    a3Detail.FutureStateUpload = _UploadFileDto.RequestData.FutureStateUpload; 
                    break;
                case 8:
                    a3Detail.FiveMiniteReviewUpload = _UploadFileDto.RequestData.FiveMiniteReviewUpload;
                    break;
                case 4:
                    a3Detail.AnalysisAndRootCauseRcupload = _UploadFileDto.RequestData.AnalysisAndRootCauseRcupload;
                    break;
                case 7:
                    a3Detail.StandardizationUpload = _UploadFileDto.RequestData.StandardizationUpload;
                    break;
                case 5:
                    a3Detail.CountermeasuresCmupload = _UploadFileDto.RequestData.CountermeasuresCmupload; 
                    break;

                case 2: a3Detail.CurrentStateUpload = _UploadFileDto.RequestData.CurrentStateUpload;
                    break;

                default:
                    break;
            }

          
            await UnitOfWork.A3detail.Update(a3Detail);

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
        public async Task<ActionResultDto> UpdateA3(RequestDto<A3Dto> A3Dto)
        {
            var result = new ActionResultDto();

            A3header a3Header = UnitOfWork.A3Header.GetWhere(a => a.A3headerId == A3Dto.RequestData.A3headerId).FirstOrDefault();

            a3Header.A3Number = int.Parse("0" + A3Dto.RequestData.A3number);
            a3Header.TeamCoachId = A3Dto.RequestData.TeamCoachId;
            a3Header.TeamLeadUserId = A3Dto.RequestData.TeamLeadUserId;
            a3Header.Title = A3Dto.RequestData.Title;
            a3Header.Process = A3Dto.RequestData.Process;
            a3Header.IssuedDate = A3Dto.RequestData.IssuedDate;
            a3Header.IssuedByUserId = A3Dto.RequestData.IssuedByUserId;
            a3Header.DeleteStatus = 0;
            a3Header.StuffNumber = A3Dto.RequestData.StuffNumber;
            a3Header.StatuesId = A3Dto.RequestData.StatuesId;

            await UnitOfWork.A3Header.Update(a3Header);


            A3details a3Detail = UnitOfWork.A3detail.GetWhere(a => a.A3headerId == A3Dto.RequestData.A3headerId).FirstOrDefault();
            a3Detail.StandardizationDes = A3Dto.RequestData.StandardizationDes; 
            a3Detail.CountermeasuresCmdes = A3Dto.RequestData.CountermeasuresCmdes; 
            a3Detail.CurrentStateDes = A3Dto.RequestData.CurrentStateDes;
            a3Detail.AssuranceDes = A3Dto.RequestData.AssuranceDes;         
            a3Detail.BackgroundDes = A3Dto.RequestData.BackgroundDes;
            a3Detail.FutureStateDes = A3Dto.RequestData.FutureStateDes;
            a3Detail.FiveMiniteReviewDes = A3Dto.RequestData.FiveMiniteReviewDes;
            a3Detail.AnalysisAndRootCauseRcDes = A3Dto.RequestData.AnalysisAndRootCauseRcDes;
            //a3Detail.AssuranceUpload = A3Dto.RequestData.AssuranceUpload;
            //a3Detail.BackgroundUpload = A3Dto.RequestData.BackgroundUpload;         
            //a3Detail.FutureStateUpload = A3Dto.RequestData.FutureStateUpload;
            //a3Detail.FiveMiniteReviewUpload = A3Dto.RequestData.FiveMiniteReviewUpload;
            //a3Detail.AnalysisAndRootCauseRcupload = A3Dto.RequestData.AnalysisAndRootCauseRcupload;
            //a3Detail.StandardizationUpload = A3Dto.RequestData.StandardizationUpload;
            //a3Detail.CountermeasuresCmupload = A3Dto.RequestData.CountermeasuresCmupload;
            //a3Detail.CurrentStateUpload = A3Dto.RequestData.CurrentStateUpload;

            await UnitOfWork.A3detail.Update(a3Detail);

            //TeamMembers team = UnitOfWork.TeamMembers.GetWhere(a => a.A3HeaderId == A3Dto.RequestData.A3headerId).FirstOrDefault();
            //team.A3HeaderId = A3Dto.RequestData.A3headerId;
      
            //await UnitOfWork.TeamMembers.Update(team);

            if (await UnitOfWork.Commit() > default(int))
            {
                result.SetResult(true, MessageResource.DataAddededSuccessfully(1), a3Header.A3headerId);
            }
            else
            {
                result.SetResult(false, MessageResource.NotDataFound(1));
            }

            return result;


        }
    }
}
