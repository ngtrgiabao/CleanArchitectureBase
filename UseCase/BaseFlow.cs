using Core; 

namespace UseCase
{
    public class BaseFlow
    {
        protected readonly DataContext dbContext; 
        public BaseFlow(DataContext ctx)
        {
            dbContext = ctx;
        }
    }
}
