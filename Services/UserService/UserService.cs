using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace piktureAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }   

        private static List<User> users = new List<User>
        {
            new User
            {
                id = 1,
                firstName = "Hung",
                lastName = "Luu"
            }
        };
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
    }
}
