using Core.Models; 
namespace Core.Interfaces
{
    public interface ISeedService
    {
        Task<ResponseModel> Execute(List<RouterModel> routers);
    }
}
