using Core.Interfaces;
using Core.Schemas;
using Core;

namespace Infrastructure.Services
{
    public class GroupService : BaseService<GroupSchema, DataContext>, IGroupService
    {
        DataContext context;
        public GroupService(DataContext _ctx) : base(_ctx)
        {
            context = _ctx;
        }

        public GroupSchema FindGroupByName(string name)
        {
            var group = context.Groups.FirstOrDefault(u => u.Name == name);
            return group;
        }
    }
}
