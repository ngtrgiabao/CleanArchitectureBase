using Core.Schemas; 

namespace Core.Interfaces
{
    public interface IGroupService : IBaseService<GroupSchema>
    {
        GroupSchema FindGroupByName(string name);
	}
}
