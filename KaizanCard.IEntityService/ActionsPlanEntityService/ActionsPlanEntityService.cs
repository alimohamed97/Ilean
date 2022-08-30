using Application.Auth;
using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Data.Entity.Entities;
using IRepository.Data;
using Lean.Data.EntityService.Base;
using Lean.Data.IEntityService.EntityDTO;
using Lean.Data.IEntityService.IActionService;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Core.Enum.Common;

namespace Lean.Data.EntityService.Action
{
    internal class ActionsPlanEntityService : BaseEntityService, IActionsPlanEntityService
    {
        public ActionsPlanEntityService(IUnitOfWork unitOfWork, IMessageResourceReader messageResource) :
            base(unitOfWork, messageResource)
        {
        }

        public async Task<ActionResultDto> CreateActionsPlan(RequestDto<A3ActionsPlanDto> ActionDto)
        {
            var result = new ActionResultDto();

            ActionsPlan action = new ActionsPlan()
            {

                Action = ActionDto.RequestData.Action,
                ActionPlanStatuesID = ActionDto.RequestData.ActionPlanStatuesID,
                CreatedDate = DateTime.Now,
                DueData = ActionDto.RequestData.DueData,
                UserIdstuffNo = ActionDto.RequestData.UserIdstuffNo,
                A3headerId = ActionDto.RequestData.A3headerId,
                DeleteStatus = 0,

            };
            UnitOfWork.ActionsPlan.Add(action);


            if (await UnitOfWork.Commit() > default(int))
            {
                result.SetResult(true, MessageResource.DataAddededSuccessfully(ActionDto.Language));
            }
            else
            {
                result.SetResult(false, MessageResource.NotDataFound(ActionDto.Language));
            }

            return result;
        }

        public async Task<A3ActionsPlanDto> GetActionsPlanByID(RequestDto<IdentityDto<int>> ActionID)
        {
            var result = new A3ActionsPlanDto();

            ActionsPlan actionsPlan = await UnitOfWork.ActionsPlan.FirstOrDefaultAsync(a => a.ActionsPlanId == ActionID.RequestData.Identity);

            A3ActionsPlanDto _a3ActionDto = new A3ActionsPlanDto
            {
                //ActionsPlanId = actionsPlan.ActionsPlanId,
                DueData = actionsPlan.DueData,
                ActionPlanStatuesID = actionsPlan.ActionPlanStatuesID,
                Name = actionsPlan.User.UserName,
                UserIdstuffNo = actionsPlan.UserIdstuffNo,
                A3headerId = actionsPlan.A3headerId,
                //DeleteStatus = actionsPlan.DeleteStatus,
            };

            return _a3ActionDto;
        }

        public async Task<PageList<A3ActionsPlanDtoList>> GetAllActionsPlan(RequestDto<IdentityDto<int>> request)
        {
            PageList<A3ActionsPlanDtoList> pageList = new PageList<A3ActionsPlanDtoList>();

            Expression<Func<ActionsPlan, bool>> filter = a=> a.A3headerId == request.RequestData.Identity ;

            List<ActionsPlan> ActionsPlanList = new List<ActionsPlan>();

            ActionsPlanList = await UnitOfWork.ActionsPlan.GetAll(a => a.A3headerId == request.RequestData.Identity && a.DeleteStatus == 0);

            if (ActionsPlanList?.Count > default(int))
            {
                List<A3ActionsPlanDtoList> actionsPlanDto = new List<A3ActionsPlanDtoList>();
                foreach (ActionsPlan o in ActionsPlanList)
                {
                    actionsPlanDto.Add(new A3ActionsPlanDtoList
                    {
                        Action = o.Action,
                        Name = o.User.UserName,
                        DueData = o.DueData,
                        ActionPlanStatuesID = o.ActionPlanStatuesID,
                        UserIdstuffNo = o.UserIdstuffNo,
                        A3headerId = o.A3headerId,  
                        DeleteStatus=0,
                        StuffNumber = o.User.StuffNumber,
                        StatuesName= o.ActionPlanStatues.ActionPlanStatuesTital,
                       ActionsPlanId = o.ActionsPlanId
                        

                    });
                }

                pageList.SetResult(await UnitOfWork.ActionsPlan.GetCount(filter), actionsPlanDto);
            }

            return pageList;
        }

        public async Task<ActionResultDto> UpdateActionsPlan(RequestDto<A3ActionsPlanDto> ActionDto)
        {
            ActionsPlan actions = await UnitOfWork.ActionsPlan.FirstOrDefaultAsync(a => a.ActionsPlanId == 1);

            var result = new ActionResultDto();
        
     
            actions.Action = ActionDto.RequestData.Action;
            actions.DueData = ActionDto.RequestData.DueData;
            actions.UserIdstuffNo = ActionDto.RequestData.UserIdstuffNo;
           // actions.Name = ActionDto.RequestData.Name;
            actions.ActionPlanStatuesID = ActionDto.RequestData.ActionPlanStatuesID;
            actions.A3headerId = ActionDto.RequestData.A3headerId;
            await UnitOfWork.ActionsPlan.Update(actions);

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

        public async Task<ActionResultDto> DeleteActionPlan(RequestDto<IdentityDto<int>> _identity)
        {
            ActionResultDto result = new ActionResultDto();

            ActionsPlan actionsPlan = await UnitOfWork.ActionsPlan.FirstOrDefaultAsync(a => a.ActionsPlanId == _identity.RequestData.Identity &&
            a.DeleteStatus == (byte)DeleteStatus.NotDeleted);

            if (actionsPlan == null)
            {
                result.SetResult(false, MessageResource.NotDataFound(1));
                return result;
            }
            actionsPlan.DeleteStatus = (byte)DeleteStatus.Deleted;

            await UnitOfWork.ActionsPlan.Update(actionsPlan);

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
    }
}
