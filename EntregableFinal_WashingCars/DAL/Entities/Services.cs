using System.ComponentModel.DataAnnotations;

namespace EntregableFinal_WashingCars.DAL.Entities
{
    public class Services : Entity
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public float Price { get; set; }

    }
}
