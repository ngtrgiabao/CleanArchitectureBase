using System.ComponentModel.DataAnnotations;

namespace Application.Controllers.Manager.Role.Presenter
{
    public class CreateRolePresenter
    {
        [Required]
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
