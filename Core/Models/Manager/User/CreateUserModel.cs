using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Manager.User
{
    public class CreateUserModel
    {
        public string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Password { get; set; }
        public string? Mobile { get; set; }
        public bool? Gender { get; set; }
        public bool? Relationship { get; set; }
        public string Bio { get; set; }
        public string? Avatar { get; set; }
        public string? Background { get; set; }
        public int? Status { get; set; }
        public int? Dob { get; set; }
        public long ProvinceId { get; set; }
        public long DistrictId { get; set; }
        public long WardId { get; set; }
        public List<long> RoleIds {  get; set; }
    }
}
