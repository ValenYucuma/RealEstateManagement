﻿using Microsoft.AspNetCore.Mvc;
using RealEstateManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Services
{
    public interface IAuthService
    {
        string GenerateToken(User user); // Genera un token JWT para el usuario
        string Authenticate(string username, string password); // Valida las credenciales del usuario

    }


}
