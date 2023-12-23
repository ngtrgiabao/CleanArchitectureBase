using Core.Interfaces;
using Core.Schemas;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class PermService : BaseService<PermSchema, DataContext>, IPermService
    {
        DataContext context;
        public PermService(DataContext _ctx) : base(_ctx)
        {
            context = _ctx;
        }

        public async Task<List<PermSchema>> GetPerms(long userId)
        {
            var perms = await (from p in context.Perms
                               join gp in context.RolesPerms on p.Id equals gp.Perm.Id
                               join g in context.Roles on gp.Role.Id equals g.Id
                               join ug in context.UsersRoles on g.Id equals ug.RoleId
                               where ug.UserId == userId
                               select new PermSchema { Id = p.Id, Module = p.Module, Action = p.Action, Title = p.Title }).ToListAsync();
            return perms;
        }
    }
}
