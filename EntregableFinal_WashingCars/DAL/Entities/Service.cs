using System.ComponentModel.DataAnnotations;

namespace EntregableFinal_WashingCars.DAL.Entities
{
    public class Service : Entity
    {
        public int ServicesId { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Price { get; set; }

    }
}
