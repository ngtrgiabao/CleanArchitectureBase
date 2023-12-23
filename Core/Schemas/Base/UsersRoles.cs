using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Schemas
{
    public class UsersRoles
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		public long RoleId { get; set; }
		[ForeignKey(nameof(RoleId))]
		public RoleSchema Role { get; set; }

		public long UserId { get; set; }
		[ForeignKey(nameof(UserId))]
		public UserSchema User { get; set; }
	}
}
