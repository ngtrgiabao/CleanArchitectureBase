using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Schemas.User;
using static Core.Business.GroupRule;

namespace Core.Schemas
{
    public class GroupSchema: BaseSchema
    {
        [Required]
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }

		[Required]
		[StringLength(20)]
		public string Name { get; set; }

		[Required]
        [StringLength(75)]
        public string Title { get; set; }

        [StringLength(100)]
        public string MetaTitle { get; set; }

        [Required]
        [StringLength(100)]
        public string Slug { get; set; }

        public string Summary { get; set; }

        [Required]
        public GroupStatus Status { get; set; }

        public string Profile { get; set; }

        public string Content { get; set; }

        [ForeignKey("CreatedBy")]
        public UserSchema Creator { get; set; }

        [ForeignKey("UpdatedBy")]
        public UserSchema? Modifier { get; set; }
    }
}
