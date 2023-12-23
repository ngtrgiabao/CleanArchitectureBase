using Core.Models;
using Infrastructure.Services;
using Core;
using UseCase.Auth;
using AutoMapper;
using Core.Models.AuthModel;
using Core.Constant;
using Application.Controllers.PublicCtrl.Presenter;

namespace Application.Controllers.PublicCtrl
{
    public class LoginCtrl
    {
        private readonly IMapper _mapper;
        private readonly LoginFlow workflow;
        private readonly byte[] secretKey;

        public LoginCtrl(DataContext ctx, byte[] _secretKey, IMapper mapper)
        {
            secretKey = _secretKey;
            _mapper = mapper;
            workflow = new LoginFlow(new UserService(ctx));
        }

        public IResult Execute(LoginPresenter authPresenter)
        {
            LoginModel model = _mapper.Map<LoginModel>(authPresenter);
            ResponseModel response = workflow.Execute(model, secretKey);
            if (response.Status == GlobalVariable.ERROR)
            {
                return Results.BadRequest();
            }
            return Results.Ok(response.Result);
        }
    }
}
