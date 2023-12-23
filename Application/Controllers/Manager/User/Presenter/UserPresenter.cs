using Core.Schemas;

namespace Application.Controllers.Manager.User.Presenter
{
    public class UserPresenter
    {
        public static List<object> PresentList(List<UserSchema> items)
        {
            var result = new List<object>();
            foreach (var item in items)
            {
                var user = PresentItem(item);
                result.Add(user);
            }
            return result;
        }

        public static object PresentItem(UserSchema item)
        {

            return new
            {
				item.Id,
				item.Email,
				item.FirstName,
				item.LastName,
				item.LastLogin,
				item.Mobile,
				item.Gender,
				item.Relationship,
				item.Bio,
				item.Avatar,
				item.Background,
				item.Status,
				item.Dob,
				item.IsOnline,
				item.ProvinceId,
				item.DistrictId,
				item.WardId,
			};
        }
    }
}
