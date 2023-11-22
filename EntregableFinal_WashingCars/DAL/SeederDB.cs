using EntregableFinal_WashingCars.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntregableFinal_WashingCars.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;//Inyección de dependencias de la BD

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }//Constructor

        public async Task SeederAsync()//Metodo SeederAsync para prepoblar las tabals de BD
        {
            await _context.Database.EnsureCreatedAsync();//Método propio de EF, metodo para crear la BD apenas mi API se ejecute

            await _context.SaveChangesAsync();
        }

        #region Private Methods
        public static void PopulateServices(ModelBuilder modelBuilder)
        {
            {
                modelBuilder.Entity<Services>().HasData(
                new Services { Id = new Guid(), Name = "Lavada simple", Price = 25000 },
                new Services { Id = new Guid(), Name = "Lavada + Polishada", Price = 50000 },
                new Services { Id = new Guid(), Name = "Lavada + Aspirada de Cojinería", Price = 30000 },
                new Services { Id = new Guid(), Name = "Lavada Full", Price = 65000 },
                new Services { Id = new Guid(), Name = "Lavada en seco del Motor", Price = 80000 },
                new Services { Id = new Guid(), Name = "Lavada Chasis", Price = 90000 }
                );
            }
        }

        #endregion

    }
}
