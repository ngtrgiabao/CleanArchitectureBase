using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Schemas
{
	public class RolesPerms
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		public long RoleId { get; set; }
		[ForeignKey(nameof(RoleId))]
		public RoleSchema Role { get; set; }

		public long PermId { get; set; }
		[ForeignKey(nameof(PermId))]
		public PermSchema Perm { get; set; }
	}
}