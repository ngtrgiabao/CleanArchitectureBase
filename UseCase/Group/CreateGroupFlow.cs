using Core;
using Core.Business;
using Core.Constant;
using Core.Models;
using Core.Models.Group;
using Core.Schemas;

using static Core.Business.GroupRule;

namespace UseCase.Group
{
	public class CreateGroupFlow : BaseFlow
	{
		public CreateGroupFlow(DataContext ctx) : base(ctx) { }
			public async Task<ResponseModel> Execute(CreateGroupModel model)
			{
				var groupExist = dbContext.Groups.FirstOrDefault(x => x.Name == model.Name);
				if (groupExist != null)
				{
					return new ResponseModel(GlobalVariable.ERROR, new { });
				}

				GroupSchema group = new GroupSchema()
				{
					Title = model.Title,
					MetaTitle = model.MetaTitle,
					Summary = model.Summary,
					Status = GroupStatus.ACTIVE,
					Profile = model.Profile,
					Slug = SlugUtil.GenerateSlug(model.Name),
					Content = model.Content,
					CreatedAt = DateTime.UtcNow,
					CreatedBy = model.CreatedBy,
					Name = model.Name
				};

				await dbContext.Groups.AddAsync(group);
				await dbContext.SaveChangesAsync();

				return new ResponseModel(GlobalVariable.SUCCESS, group);

			}

	}
}	
