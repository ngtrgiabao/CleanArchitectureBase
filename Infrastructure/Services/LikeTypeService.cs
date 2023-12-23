using Core.Interfaces;
using Core.Schemas;
using Core;

namespace Infrastructure.Services
{
    public class LikeTypeService : BaseService<LikeTypeSchema, DataContext>, ILikeTypeService
    {
        DataContext context;
        public LikeTypeService(DataContext _ctx) : base(_ctx)
        {
            context = _ctx;
        }
    }
}
