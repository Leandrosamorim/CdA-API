using Domain.Models.Auth;

namespace Domain.Interfaces.Services
{
    public interface IUserServices
    {
        public Task<User> Add(User user);
        public Task<User> GetUser(string username, string password);
    }
}