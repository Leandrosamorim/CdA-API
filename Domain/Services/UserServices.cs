using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Add(User user)
        {
            await _userRepository.Add(user);
            return user;
        }

        public async Task<User> GetUser(string username, string password)
            => await _userRepository.GetUser(username, password);
    }
}
