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

            PopulateServicesAsync();

            await _context.SaveChangesAsync();
        }

        private async Task PopulateServicesAsync()
        {
            if (!_context.Services.Any())
            {
                await AddServiceIfNotExistsAsync("Lavada simple", "25.000");
                await AddServiceIfNotExistsAsync("Lavada + Polishada", "50.000");
                await AddServiceIfNotExistsAsync("Lavada + Aspirada de Cojinería", "30.000");
                await AddServiceIfNotExistsAsync("Lavada Full", "65.000");
                await AddServiceIfNotExistsAsync("Lavada en seco del Motor", "80.000");
                await AddServiceIfNotExistsAsync("Lavada Chasis", "90.000");
            }
        }

        private async Task AddServiceIfNotExistsAsync(string serviceName, string price)
        {
            if (!_context.Services.Any(s => s.Name == serviceName && s.Price == price))
            {
                _context.Services.Add(new Entities.Service { Name = serviceName, Price = price });
                await _context.SaveChangesAsync();
            }
        }
    }
}