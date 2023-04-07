namespace piktureAPI.Services.UserService
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();
    }
}
