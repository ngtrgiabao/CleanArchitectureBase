using AutoMapper;
using Core.Models;
using Core;
using Microsoft.AspNetCore.SignalR; 
using Core.Interfaces;
using Core.Models.Group;
using Application.Controllers.Group.Presenter;
using Application.Helpers;
using Core.Constant; 
using Infrastructure.SignalRHub;

namespace Application.Controllers.Group
{
    public class GroupCtrl : BaseController
    {
		public GroupCtrl(HttpContext _httpContext, DataContext ctx, byte[] _secretKey, IMapper mapper, IHubContext<SignalrHub, IHubClientService> _hub)
            : base(_httpContext, ctx, _secretKey, mapper, _hub) {
		}

        public async Task<IResult> FetchCategory()
        {
            ResponseModel response = await fetchCategoryFlow.Execute();
            return Results.Ok(response);
        }

        public async Task<IResult> FetchGroupSuggest()
        {
            ResponseModel response = await fetchGroupSuggestFlow.Execute();
            return Results.Ok(response);
        }


        public async Task<IResult> FetchTagGroup()
        {
            ResponseModel response = await fetchTagGroupFlow.Execute();
            return Results.Ok(response);
        }

        public async Task<IResult> Create(CreateGroupPresenter model)
        {
			long userId = Common.GetCurrentUserId(httpContext);
			CreateGroupModel group = mapper.Map<CreateGroupModel>(model);
			group.CreatedBy = userId;

			ResponseModel response = await createGroupFlow.Execute(group);
			if (response.Status == GlobalVariable.ERROR)
			{
				return Results.BadRequest();
			}
			return Results.Ok(response);
		}

		public async Task<IResult> Update(UpdateGroupPresenter model)
		{
			long userId = Common.GetCurrentUserId(httpContext);
			UpdateGroupModel group = mapper.Map<UpdateGroupModel>(model);
            group.UpdatedBy = userId;
			ResponseModel response = await updateGroupFlow.Execute(group);
			if (response.Status == GlobalVariable.ERROR)
			{
				return Results.BadRequest();
			}
			return Results.Ok(response);
		}

		public IResult Delete(long groupId)
		{
			long userId = Common.GetCurrentUserId(httpContext);
			var group = context.Groups.FirstOrDefault(u => u.Id == groupId && u.CreatedBy == userId);
			if (group == null)
			{
				return Results.BadRequest();
			}
		    context.Groups.Remove(group);

			return Results.NoContent();
		}

	
	}
}
