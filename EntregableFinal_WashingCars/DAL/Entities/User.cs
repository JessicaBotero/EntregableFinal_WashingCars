using EntregableFinal_WashingCars.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace EntregableFinal_WashingCars.DAL.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Fecha de creación")]
        public  DateTime? CreatedDate { get; set; }


        [Display(Name = "Fecha de modificación")]
        public  DateTime? ModifiedDate { get; set; }


        [Display(Name = "Documento")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        
        public string Document { get; set; }
        

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }


        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }


        [Display(Name = "Número de Teléfono")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PhoneNumber { get; set; }



        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7158/images/NoImage.png"
            : $"https://sales2023.blob.core.windows.net/users/{ImageId}";


        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }


        [Display(Name = "Vehículo")]
        public Vehicle Vehicle { get; set; }


        //Propiedades de Lectura - No se muestran en base de datos por que son solo lectura
        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Usuario")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";


    }
}
