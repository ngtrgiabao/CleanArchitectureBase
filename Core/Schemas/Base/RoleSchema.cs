 namespace Core.Schemas
{
    public class RoleSchema : BaseSchema
    {
        public string Title { get; set; }
        public string? ProfileType { get; set; }
        public string Description { get; set; }

        public ICollection<RolesPerms>? RolesPerms { get; set; }

    }
}
