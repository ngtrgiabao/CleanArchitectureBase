
using Core.Models.Feed;
using Core.Schemas;
using Core.Constant;
using System.Linq;

namespace Core.Business
{
    public class FeedRule
    {
        public static int GetPostType(PostModel model)
        {
            if (model.Images.Length == 1)
            {
                return (int)GlobalVariable.POST_TYPE.IMAGE;
            }
            else if (model.Images.Length > 1)
            {
                return (int)GlobalVariable.POST_TYPE.SLIDE;
            }
            return (int)GlobalVariable.POST_TYPE.TEXT;
        }

        public static object GetPost(PostSchema post)
        {
            return new
            {
                post.Id,
                post.Content,
                post.Type,
                post.Likes,
                /*post.Images,*/
                images = GetImages(post),
                timePosted = TimeUtil.GetTimeString((DateTime)post.CreatedAt),
                comment = GetComment(post)
                /* 
                 Poster = GetPoster(post),
                 */
            };
        }

        private static object GetPoster(PostSchema post)
        {
            return new
            {
                post.Poster.Id,
                FullName = post.Poster.FirstName + " " + post.Poster.LastName,
                post.Poster.Avatar,
            };
        }

        private static object GetImages(PostSchema post)
        {
            return new
            {
                hasNext = false,
                total = post.Images.Count(),
                items = post.Images.Select(img => new
                {
                    imgUrl = img
                })
            };
        }

        private static object GetComment(PostSchema post)
        {
            return new
            {
                hasNext = false,
                total = post.Comments.Count(),
                items = post.Comments.Select(cmt => new
                {
                    cmt.Id,
                    cmt.Content,
                    cmt.Link,
                    cmt.UserId,
                    cmt.PostId,
                    timeCommented = TimeUtil.GetTimeString((DateTime)cmt.CreatedAt),
                    commenter = new
                    {
                        fullName = cmt.Commenter.FirstName + cmt.Commenter.LastName,
                        cmt.Commenter.Id,
                        cmt.Commenter.Avatar,
                    }
                })
            };
        }
    }
}
