using System.ComponentModel.DataAnnotations;

namespace EntregableFinal_WashingCars.DAL.Entities
{
    public class VehicleDetail : Entity
    {
        [Key]
        [Required]
        public Guid? VehiculeId { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "Fecha de Entrega")]
        public DateTime? DeliveryDate { get; set; }
    }
}
