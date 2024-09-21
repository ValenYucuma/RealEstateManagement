using RealEstateManagement.Domain.Entities;
using RealEstateManagement.Domain.Interfaces;
using RealEstateManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RealEstateContext _context; // Tu contexto de datos

        public UserRepository(RealEstateContext context)
        {
            _context = context;
        }

        public User GetByUsername(string username)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username);
        }

        public User GetById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int userId)
        {
            var user = GetById(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }

}
