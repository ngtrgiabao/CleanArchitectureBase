using Application.Controllers.Feed.Presenter;
using Application.Controllers.Manager.Post.Presenter;
using AutoMapper;
using Core;
using Core.Constant;
using Core.Interfaces;
using Core.Models.Feed;
using Core.Models.Manager.Post;
using Core.Schemas;
using Infrastructure.Services;
using UseCase.Manager.Post;

namespace Application.Controllers.Manager.Post
{
    public class PostManagerCtrl
    {
        private readonly IMapper _mapper;
        private readonly IPostService postService;
        private readonly CreatePostFlow createPostFlow;
        private readonly UpdatePostFlow updatePostFlow;

        public PostManagerCtrl(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            postService = new PostService(ctx);
            createPostFlow = new CreatePostFlow(postService);
            updatePostFlow = new UpdatePostFlow(postService);
        }

        public async Task<IResult> GetPostById(long id)
        {
            PostSchema existingPost = await postService.Get(id);

            if (existingPost == null)
            {
                return Results.BadRequest("Post not found");
            }

            return Results.Ok(existingPost);
        }

        public async Task<IResult> Get()
        {
            var posts = await postService.GetAll();
            var response = PostPresenter.PresentList(posts);

            return Results.Ok(response);
        }

        public async Task<IResult> Create(CreatePostPresenter model)
        {
            PostModel post = _mapper.Map<PostModel>(model);
            var response = await createPostFlow.Excute(post);

            if (response.Status == GlobalVariable.ERROR)
            {
                return Results.BadRequest();
            }

            return Results.Ok(response);
        }

        public async Task<IResult> Update(UpdatePostPresenter model, long id)
        {
            PostSchema existingPost = await postService.Get(id);

            if (existingPost == null)
            {
                return Results.BadRequest("Post not found, can't update");
            }

            UpdatePostModel post = _mapper.Map<UpdatePostModel>(model);
            var response = await updatePostFlow.Excute(post, id);

            if (response.Status == GlobalVariable.ERROR)
            {
                return Results.BadRequest();
            }

            return Results.Ok(response);
        }

        public async Task<IResult> Delete(long id)
        {
            PostSchema existingPost = await postService.Get(id);

            if (existingPost == null)
            {
                return Results.BadRequest("Post not found, can't delete");
            }

            var response = await postService.Delete(id);
            return Results.Ok(response);
        }
    }
}
