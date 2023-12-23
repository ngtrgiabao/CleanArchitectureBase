using System.ComponentModel.DataAnnotations;

namespace Application.Controllers.Manager.Role.Presenter
{
    public class UpdateRolePresenter
    {

        [Required]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
