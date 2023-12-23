using System.ComponentModel.DataAnnotations;

namespace Application.Controllers.Manager.User.Presenter
{
    public class CreateUserPresenter
    {
		[Required]
		[EmailAddress]
		public string Email { get; set; } = "";

        [MaxLength(20)]
		public string? FirstName { get; set; }

		[MaxLength(20)]
		public string? LastName { get; set; }

		[Required]
		[MaxLength(20)]
		public string Password { get; set; } = "";
        public string? Mobile { get; set; }
		public bool? Gender { get; set; }
		public bool? Relationship { get; set; }

		[Required]
		[MaxLength(100)]
		public string Bio { get; set; } = "";

        public string? Avatar { get; set; }
		public string? Background { get; set; }

		public int? Status { get; set; }

		public int? Dob { get; set; }

		[Required]
		public long ProvinceId { get; set; }
		[Required]
		public long DistrictId { get; set; }

		[Required]
		public long WardId { get; set; }
		public List<long> RoleIds { get; set; }

	}
}
