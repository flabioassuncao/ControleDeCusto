using System.ComponentModel.DataAnnotations;

namespace ControleDeCustos.Infra.Identity.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
