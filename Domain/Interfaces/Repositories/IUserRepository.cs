using Domain.Models.Auth;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<string> GetUserNameById(int Id);
        public Task Add(User user);
        public Task<User> GetUser(string userName, string password);
    }
}