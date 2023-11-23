using System.ComponentModel.DataAnnotations;

namespace EntregableFinal_WashingCars.DAL.Entities
{
    public class Vehicle : Entity
    {
        [Key]
        [Required]
        public Guid? ServiceId { get; set; }

        [Required]
        [Display(Name = "Propietario")]
        public String? Owner { get; set; }

        [Required]
        [Display(Name = "Número de Placa")]
        public String? NumberPlate { get; set; }


        [Display(Name = "Usuarios")]
        public ICollection<User> Users { get; set; }

    }


}
