using System.ComponentModel.DataAnnotations;

namespace Application.Controllers.PublicCtrl.Presenter
{
    public class RegisterPresenter
    {

        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}
