using Data.Context;
using Domain.Interfaces.Repositories;
using Domain.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<string> GetUserNameById(int id)
        {
            return (await _context.User.FindAsync(id)).UserName;
        }

        public async Task Add(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public async Task<User> GetUser(string userName, string password)
        {
            return (await _context.User.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password));
        }



    }
}
