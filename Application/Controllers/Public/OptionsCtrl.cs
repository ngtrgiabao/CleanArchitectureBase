using Core.Constant;
using Core.Models;

namespace Application.Controllers.Public
{ 
    public class OptionsCtrl
    {
        public IResult Get()
        {
            OptionsModel model = new OptionsModel();
            model.Address.Provinces =  AddressUtil.GetProvinceModels();
            model.Address.Districts = AddressUtil.GetDistrictModels();
            model.Address.Wards = AddressUtil.GetWardModels();

            return Results.Ok(model);
        }
    }
}
