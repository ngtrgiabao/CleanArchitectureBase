using AutoMapper;
using Core.Schemas;
using System.ComponentModel.DataAnnotations;

namespace Application.Controllers.Manager.Post.Presenter
{
    public class UpdatePostPresenter
    {
        public string? Content { get; set; }
        public string[]? Images { get; set; }
        [Required]
        [MinLength(1)]
        public long UserId { get; set; }
    }
}
