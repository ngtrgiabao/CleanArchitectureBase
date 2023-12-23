using Application.Controllers.Manager.User.Presenter;
using AutoMapper;
using Core;
using Core.Business;
using Core.Constant;
using Core.Interfaces;
using Core.Models.Manager.User;
using Core.Schemas;
using Infrastructure.Services;
using UseCase.Auth;
using UseCase.Manager.User;

namespace Application.Controllers.Manager.User
{
    public class UserManagerCtrl
    {
        private readonly IMapper _mapper;
        private readonly IUserService userService;
		private readonly IRoleService roleService;
		private readonly CreateUserFlow createUserFlow;
		private readonly UpdateUserFlow updateUserFlow;

		public UserManagerCtrl(IMapper mapper, DataContext ctx )
        {
            _mapper = mapper;
            userService = new UserService(ctx);
			roleService = new RoleService(ctx);
			createUserFlow = new CreateUserFlow(userService, roleService);
			updateUserFlow = new UpdateUserFlow(userService, roleService);
		}

		public async Task<IResult> Get()
        {
            var users = await userService.GetAll();
            users = UserRule.RemoveDefaultAccount(users);
            var response = UserPresenter.PresentList(users);
            return Results.Ok(response);
        }

		public async Task<IResult> GetUsersWithRoles()
		{
			var users = userService.GetUsersWithRoles();
			users = UserRule.RemoveDefaultAccount(users);
			return Results.Ok(users);
		}

		public async Task<IResult> Create(CreateUserPresenter model)
        {
			CreateUserModel user = _mapper.Map<CreateUserModel>(model);
            var response = await createUserFlow.Execute(user);
			if (response.Status == GlobalVariable.ERROR)
			{
				return Results.BadRequest();
			}
			return Results.Ok(response);
        }

        public async Task<IResult> Update(UpdateUserPresenter model)
        {
			UpdateUserModel user = _mapper.Map<UpdateUserModel>(model);
			var response = await updateUserFlow.Execute(user);
			if (response.Status == GlobalVariable.ERROR)
			{
				return Results.BadRequest();
			}
			return Results.Ok(response);
        }

		public IResult Delete(long id)
		{
			userService.Delete(id);
			return Results.NoContent();
		}
	}
}
