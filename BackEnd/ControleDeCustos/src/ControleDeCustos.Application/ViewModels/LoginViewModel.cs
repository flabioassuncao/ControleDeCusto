using System.ComponentModel.DataAnnotations;

namespace ControleDeCustos.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Senha { get; set; }
    }
}
