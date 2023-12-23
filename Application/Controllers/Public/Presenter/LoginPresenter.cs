using System.ComponentModel.DataAnnotations;

namespace Application.Controllers.PublicCtrl.Presenter
{
    public class LoginPresenter
    {
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";

    }
}
