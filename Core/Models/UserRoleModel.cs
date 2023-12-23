 namespace Core.Models
{
    public class UserRoleModel
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
		public string? LastName { get; set; }
		public string? FirstName { get; set; }
		public bool? Gender { get; set; }
		public bool? Relationship { get; set; }
		public string Email { get; set; }
		public int? Status { get; set; }
		public string? Mobile { get; set; }
		public string? Bio { get; set; }
		public string? Avatar { get; set; }
		public string? Background { get; set; }
		public int? Dob { get; set; }
		public string? IsOnline { get; set; }
		public long? ProvinceId { get; set; }
		public long? DistrictId { get; set; }
		public long? WardId { get; set; }

		public List<RoleModel> Roles { get; set; }
    }
}
