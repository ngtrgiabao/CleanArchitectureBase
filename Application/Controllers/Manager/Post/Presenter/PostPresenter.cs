using Core.Schemas;

namespace Application.Controllers.Manager.Post.Presenter
{
    public class PostPresenter
    {
        public static List<object> PresentList(List<PostSchema> items)
        {
            var result = new List<object>();
            foreach (var item in items)
            {
                var post = PresentItem(item);
                result.Add(post);
            }
            return result;
        }

        public static object PresentItem(PostSchema item)
        {
            PostSchema post = new PostSchema();
            post.Id = item.Id;
            post.UserId = item.UserId;
            post.Content = item.Content;
            post.Images = item.Images;
            post.Likes = item.Likes;
            post.Comments = item.Comments;
            post.Type = item.Type;
            return post;
        }
    }
}
