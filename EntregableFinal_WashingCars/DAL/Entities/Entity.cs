using System.ComponentModel.DataAnnotations;

namespace EntregableFinal_WashingCars.DAL.Entities
{
    public class Entity
    {

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Fecha de Modificación")]
        public DateTime? ModifiedDate { get; set; }

    }
}
