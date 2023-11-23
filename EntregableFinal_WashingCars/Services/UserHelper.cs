using EntregableFinal_WashingCars.DAL;
using EntregableFinal_WashingCars.DAL.Entities;
using EntregableFinal_WashingCars.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EntregableFinal_WashingCars.Services
{
    public class UserHelper : IUserHelper
    {
        private readonly DataBaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(DataBaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) //Inyección de dependencia para acceder a la BD
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task AddRoleAsync(string roleName) 
        {
            bool roleExists  = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName,
                });

            }
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Vehicle)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string rolName)
        {
           return await _userManager.IsInRoleAsync(user, rolName);
        }
    }
}
