using Application.Controllers.Manager.Role.Presenter;
using Application.Helpers;
using AutoMapper;
using Core;
using Core.Constant;
using Core.Interfaces;
using Core.Models.Manager.Group;
using Core.Models.Manager.Role;
using Core.Schemas;
using Infrastructure.Services; 

namespace Application.Controllers.Manager.Role
{
    public class RoleManagerCtrl
    {
        private readonly IMapper mapper;
        private readonly IRoleService roleService;

		public RoleManagerCtrl(HttpContext _httpContext, DataContext _dataContext, IMapper _mapper)
        {
            mapper = _mapper;
            roleService = new RoleService(_dataContext);
        }

        public async Task<IResult> Get()
        {
            var roles = roleService.GetRolesWithPerms();
            return Results.Ok(roles);
        }
		public IResult Create(CreateRolePresenter model)
        {
			var existRole = roleService.GetRoleByTitle(model.Title);

            if(existRole != null) {
                return Results.BadRequest("Title is already used !");
            }

			CreateRoleModel roleModel = mapper.Map<CreateRoleModel>(model);

            RoleSchema role = new RoleSchema
            {
                Description = roleModel.Description,
                Title = roleModel.Title,
			};

			var response = roleService.Add(role);
            return Results.Ok(response);
        }

        public async Task<IResult> Update(UpdateRolePresenter model)
        {
			var existRole = roleService.GetRoleByTitle(model.Title);
			if (existRole != null)
			{
				return Results.BadRequest("Title is already used!");
			}

			var role = await roleService.Get(model.Id);
			if (role == null)
			{
				return Results.BadRequest("Role not found");
			}

			UpdateRoleModel roleModel = mapper.Map<UpdateRoleModel>(model);

			role.Description = roleModel.Description;
            role.Title = roleModel.Title;

			var response = roleService.Update(role);
            return Results.Ok(response);
        }

		public async Task<IResult> UpdatePermForRole(UpdatePermForRolePresenter model)
		{
            var roleModel = mapper.Map<UpdatePermForRoleModel>(model);

            var role = await roleService.Get(roleModel.RoleId);
            if (role == null)
            {
                return Results.BadRequest("Not found role");
            }

            var response = roleService.UpdatePermForRole(model.PermIds, model.RoleId);

			return Results.Ok(response);
		}

		public async Task<IResult> Delete(long id)
        {
            var role = roleService.Get(id);

            if(role == null)
            {
                return Results.BadRequest("Role not found");
            }

            await roleService.Delete(id);
            return Results.NoContent();
        }
    }
}
