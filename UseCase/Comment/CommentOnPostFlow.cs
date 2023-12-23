using Core.Constant;
using Core.Models;
using Core.Schemas;
using Core;
using Core.Models.Comment;
using static Core.Business.CommentRule;
using Microsoft.EntityFrameworkCore;

namespace UseCase.Comment
{
    public class CommentOnPostFlow : BaseFlow
    {
        public CommentOnPostFlow(DataContext dbContext) : base(dbContext) { }

        public async Task<ResponseModel> Execute(CommentOnPostModel model)
        {
            CommentSchema schema = new CommentSchema();

            schema.Content = model.Content;
            schema.Images = model.Images;
            schema.Link = model.Link == null ? model.Content : "test";
            schema.PostId = model.PostId;
            schema.UserId = model.CommenterId;
            schema.CreatedAt = DateTime.UtcNow;
            schema.Type = model.Content != null ? CommentType.TEXT : CommentType.IMAGE;
            dbContext.Comments.Add(schema);
            await dbContext.SaveChangesAsync();
            schema.Commenter = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == model.CommenterId);

            return new ResponseModel(GlobalVariable.SUCCESS, schema);
        }
    }
}
