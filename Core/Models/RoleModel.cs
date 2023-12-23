using Core.Schemas;

namespace Core.Models
{
    public class RoleModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<string> Perms { get; set; }
    }
}
