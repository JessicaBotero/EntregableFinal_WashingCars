using System.ComponentModel.DataAnnotations;

namespace EntregableFinal_WashingCars.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El campo {0} es obligatorio. ")]
        [EmailAddress(ErrorMessage = "Debes ingresar un correo valido. ")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "El campo {0} es obligatorio. ")]
        [MinLength(6, ErrorMessage = "El campo {0} debe de tener al menos {1} carácteres. ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display (Name = "Recordarme en este navegador")]
        public bool RememberMe { get; set; }
    }
}
