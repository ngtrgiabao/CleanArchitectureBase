using Core;
using Core.Business;
using Core.Constant;
using Core.Models;
using Core.Models.Group;
using Core.Schemas;

using static Core.Business.GroupRule;

namespace UseCase.Group
{
	public class UpdateGroupFlow : BaseFlow
	{
		public UpdateGroupFlow(DataContext ctx) : base(ctx) { }
		public async Task<ResponseModel> Execute(UpdateGroupModel model)
		{
			var group = dbContext.Groups.FirstOrDefault(x => x.Id == model.Id && x.CreatedBy == model.UpdatedBy);
			if (group == null)
			{
				return new ResponseModel(GlobalVariable.ERROR, new { });
			}

			var existGroupWithNewName = dbContext.Groups.FirstOrDefault(x => x.Name == model.Name);
			if (existGroupWithNewName != null) {
				return new ResponseModel(GlobalVariable.ERROR, new { });
			}


			group.Title = model.Title;
			group.MetaTitle = model.MetaTitle;
			group.Summary = model.Summary;
			group.Profile = model.Profile;
			group.Slug = SlugUtil.GenerateSlug(model.Name);
			group.Content = model.Content;
			group.UpdatedAt = DateTime.UtcNow;
			group.UpdatedBy = model.UpdatedBy;
			group.Name = model.Name;

			dbContext.Groups.Update(group);
			await dbContext.SaveChangesAsync();

			return new ResponseModel(GlobalVariable.SUCCESS, group);

		}

	}
}
