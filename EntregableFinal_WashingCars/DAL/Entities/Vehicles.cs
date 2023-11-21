using System.ComponentModel.DataAnnotations;

namespace EntregableFinal_WashingCars.DAL.Entities
{
    public class Vehicles : Entity
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
    }
}
