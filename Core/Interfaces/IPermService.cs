using Core.Schemas;

namespace Core.Interfaces
{
    public interface IPermService : IBaseService<PermSchema>
    {
       Task<List<PermSchema>> GetPerms(long userId);
    }
}
