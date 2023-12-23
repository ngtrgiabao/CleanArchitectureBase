using System.ComponentModel.DataAnnotations;

namespace Application.Controllers.Manager.User.Presenter
{
    public class UpdateUserPresenter
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; } = "";

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; } = "";

        [Required]
        [MaxLength(20)]
        public string Password { get; set; } = "";
        public string? Mobile { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public bool Relationship { get; set; }
        [MaxLength(100)]
        public string? Bio { get; set; }
        public string? Avatar { get; set; }
        public string? Background { get; set; }
        public int? Status { get; set; }
        public int? Dob { get; set; }
        public long? ProvinceId { get; set; }
        public long? DistrictId { get; set; }
        public long? WardId { get; set; }
		public List<long> RoleIds { get; set; }

	}
}
