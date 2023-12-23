using Application.Controllers.PublicCtrl.Presenter;
using AutoMapper;
using Core;
using Core.Models;
using Core.Models.AuthModel;
using Infrastructure.Services;
using UseCase.Auth;

namespace Application.Controllers.PublicCtrl
{
    public class RefreshTokenCtrl
    {
        private readonly RefreshTokenFlow workflow;
        private readonly byte[] secretKey;
        private readonly IMapper mapper;
        public RefreshTokenCtrl(DataContext ctx, byte[] _secretKey, IMapper _mapper)
        {
            secretKey = _secretKey;
            mapper = _mapper;
            workflow = new RefreshTokenFlow(new UserService(ctx));
        }

        public async Task<IResult> Execute(TokenPresenter tokenPresenter)
        {
            TokenModel model = mapper.Map<TokenModel>(tokenPresenter);
            ResponseModel response = await workflow.Execute(model, secretKey);
            return Results.Ok(response);
        }
    }
}
