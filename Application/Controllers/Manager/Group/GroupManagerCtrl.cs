using Application.Controllers.Manager.Group.Presenter;
using Application.Helpers;
using AutoMapper;
using Core;
using Core.Constant;
using Core.Interfaces;
using Core.Models.Manager.Group;
using Core.Schemas;
using Infrastructure.Services;
using Infrastructure.SignalRHub;
using Microsoft.AspNetCore.SignalR;

namespace Application.Controllers.Manager
{

    public class GroupManagerCtrl : BaseController
    {
        private readonly IGroupService groupService;

        public GroupManagerCtrl(HttpContext _httpContext, DataContext ctx, byte[] _secretKey, IMapper mapper, IHubContext<SignalrHub, IHubClientService> _hub)
            : base(_httpContext, ctx, _secretKey, mapper, _hub)
        {
            groupService = new GroupService(ctx);
        }

        public async Task<IResult> Get()
        {
            var groups = await groupService.GetAll();
            return Results.Ok(groups);
        }

        public async Task<IResult> Update(AdminUpdateGroupPresenter model)
        {
            var existGroupWithNewName = context.Groups.FirstOrDefault(x => x.Name == model.Name);
            if (existGroupWithNewName != null)
            {
                return Results.BadRequest("Name is already taken. Please try another name");
            }

            long userId = Common.GetCurrentUserId(httpContext);
            GroupSchema group = context.Groups.Find(model.Id);
            if (group == null)
            {
                return Results.BadRequest("Cant find this group");
            }

            AdminUpdateGroupModel groupModel = mapper.Map<AdminUpdateGroupModel>(model);
            group.UpdatedBy = userId;
            group.Title = groupModel.Title;
            group.MetaTitle = groupModel.MetaTitle;
            group.Summary = groupModel.Summary;
            group.Profile = groupModel.Profile;
            group.Slug = SlugUtil.GenerateSlug(groupModel.Name);
            group.Content = groupModel.Content;
            group.UpdatedAt = DateTime.UtcNow;
            group.Name = groupModel.Name;
            group.Status = groupModel.Status;

            await groupService.Update(group);
            return Results.Ok(group);
        }

        public IResult Delete(long id)
        {
            var group = groupService.Get(id);

            if (group == null)
            {
                return Results.BadRequest();
            }

            groupService.Delete(id);
            return Results.NoContent();
        }
    }
}
