using System.ComponentModel.DataAnnotations;

namespace Application.Controllers.PublicCtrl.Presenter
{
    public class RefreshTokenPresenter
    {
        [Required]
        public string AccessToken { get; set; } = "";
        [Required]
        public string RefreshToken { get; set; } = "";
    }
}
