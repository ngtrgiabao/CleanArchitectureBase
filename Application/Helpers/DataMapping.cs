using Application.Controllers.Feed.Presenter;
using Application.Controllers.Manager.Post.Presenter;
using Application.Controllers.Comment.Presenter;
using Application.Controllers.Group.Presenter;
using Application.Controllers.Manager.Group.Presenter;
using Application.Controllers.Manager.Role.Presenter;
using Application.Controllers.Manager.User.Presenter;
using Application.Controllers.PublicCtrl.Presenter;
using AutoMapper;
using Core.Models.AuthModel;
using Core.Models.Manager.Post;
using Core.Models.Comment;
using Core.Models.Feed;
using Core.Models.Group;
using Core.Models.Manager.Group;
using Core.Models.Manager.User;
using Core.Schemas;
using Application.Controllers.Manager.Comment.Presenter;
using Core.Models.Manager.Role;

namespace Application.Helpers
{
    public class DataMapping : Profile
    {
        public DataMapping()
        {
            // Default mapping when property names are same
            CreateMap<LoginPresenter, LoginModel>();
            CreateMap<RegisterPresenter, RegisterModel>();
            CreateMap<TokenPresenter, TokenModel>();
            CreateMap<CreateUserPresenter, UserSchema>();
            CreateMap<CreatePostPresenter, CreatePostModel>();
            CreateMap<UpdatePostPresenter, UpdatePostModel>();
            CreateMap<CreateUserPresenter, CreateUserModel>();
            CreateMap<UpdateUserPresenter, UpdateUserModel>();
            CreateMap<CreatePostPresenter, PostModel>();
            CreateMap<CreateRolePresenter, RoleSchema>();
            CreateMap<CommentOnPostPresenter, CommentOnPostModel>();
            CreateMap<UpdateCommentPresenter, UpdateCommentOnPostModel>();
            CreateMap<CreateGroupPresenter, CreateGroupModel>();
            CreateMap<UpdateGroupPresenter, UpdateGroupModel>();
            CreateMap<AdminUpdateGroupPresenter, AdminUpdateGroupModel>();
            CreateMap<UpdateRolePresenter, UpdateRoleModel>();
            CreateMap<CreateRolePresenter, CreateRoleModel>();
            CreateMap<UpdatePermForRolePresenter, UpdatePermForRoleModel>();


            // Mapping when property names are different
            //CreateMap<User, UserViewModel>()
            //    .ForMember(dest =>
            //    dest.FName,
            //    opt => opt.MapFrom(src => src.FirstName))
            //    .ForMember(dest =>
            //    dest.LName,
            //    opt => opt.MapFrom(src => src.LastName));
        }
    }
}
