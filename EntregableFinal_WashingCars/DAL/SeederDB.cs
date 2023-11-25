using EntregableFinal_WashingCars.DAL.Entities;
using EntregableFinal_WashingCars.Enum;
using EntregableFinal_WashingCars.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Core.Imaging;

namespace EntregableFinal_WashingCars.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;//Inyección de dependencias de la BD
        private readonly IUserHelper _userHelper;

        public SeederDB(DataBaseContext context, IUserHelper userHelper)//Constructor
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeederAsync()//Metodo SeederAsync para prepoblar las tabals de BD
        {
            await _context.Database.EnsureCreatedAsync();//Método propio de EF, metodo para crear la BD apenas mi API se ejecute

            await PopulateServicesAsync();
            await populateUserAsync();
            await PopulateRolesAsync();
            await PopulateUserAsync("Steve", "Jobs", "steve_jobs_admin@yopmail.com", "3002323232", "102030", "SteveJobs.png", UserType.Admin);
            await PopulateUserAsync("Bill", "Gates", "bill_gates_user@yopmail.com", "4005656656", "405060", "BillGates.png", UserType.Client);

            await _context.SaveChangesAsync();
        }


       
        private Task populateUserAsync()
        {
            throw new NotImplementedException();
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


        private async Task PopulateRolesAsync()
        {
            await _userHelper.AddRoleAsync(UserType.Admin.ToString());
            await _userHelper.AddRoleAsync(UserType.Client.ToString());

        }


        private async Task PopulateUserAsync(string firstName, string lastName, string email, string phone, string document, string image, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    CreatedDate = DateTime.Now,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Document = document,
                    Vehicle = _context.Vehicles.FirstOrDefault(),
                    UserType = userType,
                    //ImageId = ImageId
                };

                await _userHelper.AddUserAsync(user, "987654");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }

    }
}