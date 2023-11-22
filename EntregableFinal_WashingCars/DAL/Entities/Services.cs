using System.ComponentModel.DataAnnotations;

namespace EntregableFinal_WashingCars.DAL.Entities
{
    public class Services : Entity
    {
        [Display(Name = "Ingrese su Ticket")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int ServicesId { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public float Price { get; set; }

    }
}
