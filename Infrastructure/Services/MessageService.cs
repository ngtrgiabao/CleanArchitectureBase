using Core.Interfaces;
using Core.Schemas;
using Core; 
namespace Infrastructure.Services
{
    public class MessageService : BaseService<MessageSchema, DataContext>, IMessageService
    {
        DataContext context;
        public MessageService(DataContext _ctx) : base(_ctx)
        {
            context = _ctx;
        }
    }
}
