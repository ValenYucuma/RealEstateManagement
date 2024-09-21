using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RealEstateManagement.Application.Services;
using RealEstateManagement.Domain.Entities;
using RealEstateManagement.Domain.Interfaces;


namespace RealEstateManagement.Application.Helpers
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly IUserRepository _userRepository;

        public PasswordHasher(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string HashPassword(string password)
        {
            var hasher = new PasswordHasher<User>(); // Suponiendo que User es tu clase de usuario
            return hasher.HashPassword(null, password);
        }

        // Implementación correcta del método de verificación
        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }

        public bool ValidateUserCredentials(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null) return false;

            return VerifyHashedPassword(user.PasswordHash, password);
        }
    }

}

