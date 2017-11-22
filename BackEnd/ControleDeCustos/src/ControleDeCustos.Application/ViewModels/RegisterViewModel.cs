using System.ComponentModel.DataAnnotations;

namespace ControleDeCustos.Application.ViewModels
{
    public class RegisterViewModel
    {   
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
