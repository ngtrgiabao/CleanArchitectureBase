
using Core.Models;
using Infrastructure.Services;
using Core;
using UseCase.Auth;
using Core.Models.AuthModel;
using AutoMapper;
using Application.Controllers.PublicCtrl.Presenter;

namespace Application.Controllers.PublicCtrl
{
    public class RegisterCtrl
    {
        private readonly IMapper mapper;
        private readonly RegisterFlow workflow;
        public RegisterCtrl(DataContext ctx, IMapper _mapper)
        {
            mapper = _mapper;
            workflow = new RegisterFlow(new UserService(ctx));
        }
        public IResult Execute(RegisterPresenter registerPresenter)
        {
            RegisterModel model = mapper.Map<RegisterModel>(registerPresenter);
            ResponseModel response = workflow.Execute(model);
            return Results.Ok(response);
        }
    }
}
