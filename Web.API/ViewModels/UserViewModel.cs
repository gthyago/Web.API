using System.ComponentModel.DataAnnotations;

namespace Web.API.ViewModels
{
    public class UserViewModel
    {        
        [Required(ErrorMessage = "A senha não pode ser vazia.")]
        [MinLength(9, ErrorMessage = "A senha deve ter no mínimo 9 caracteres.")]
        [MaxLength(30, ErrorMessage = "A senha deve ter no máximo 30 caracteres.")]

        public string Password { get; set; }

    }
}
