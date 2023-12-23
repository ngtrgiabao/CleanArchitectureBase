using Core.Schemas;

namespace Application.Controllers.Manager.Comment.Presenter
{
    public class CommentPresenter
    {
        public static List<object> PresentList(List<CommentSchema> items)
        {
            var result = new List<object>();
            foreach (var item in items)
            {
                var comment = PresentItem(item);
                result.Add(comment);
            }
            return result;
        }

        public static object PresentItem(CommentSchema item)
        {
            CommentSchema comment = new CommentSchema();
            comment.Id = item.Id;
            comment.PostId = item.PostId;
            comment.Post = item.Post;
            comment.Images = item.Images;
            comment.UserId = item.UserId;
            comment.Commenter = item.Commenter;
            comment.Content = item.Content;
            comment.Type = item.Type;
            comment.Link = item.Link;
            comment.CreatedAt = item.CreatedAt;
            comment.UpdatedAt = item.UpdatedAt;
            return comment;
        }
    }
}
