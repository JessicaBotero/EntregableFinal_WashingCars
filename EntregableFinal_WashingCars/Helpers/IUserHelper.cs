using EntregableFinal_WashingCars.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace EntregableFinal_WashingCars.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email); //Captura los usuarios desde la BD

        Task<IdentityResult> AddUserAsync(User user, string password);// Adiciona los usuarios a la BD

        Task AddRoleAsync(string roleName); // Agrega los roles a las tablas de BD (Admin, Client) 

        Task AddUserToRoleAsync(User user, string roleName); // Relaciona la tabla User con Roles

        Task<bool> IsUserInRoleAsync(User user, string rolName); // Valida si el usuario ingresado esta relacionado con un rol
    }
}
