using System.ComponentModel.DataAnnotations;

namespace ControleDeCustos.Application.ViewModels
{
    public class RegisterViewModel
    {   
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Senha { get; set; }

        [Required]
        public string ConfirmarSenha { get; set; }
    }
}
