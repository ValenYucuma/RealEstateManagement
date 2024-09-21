using RealEstateManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetByUsername(string username); // Obtener un usuario por su nombre de usuario
        User GetById(int userId); // Obtener un usuario por su ID
        void Create(User user); // Crear un nuevo usuario
        void Update(User user); // Actualizar un usuario existente
        void Delete(int userId); // Eliminar un usuario por su ID
        IEnumerable<User> GetAll(); // Obtener todos los usuarios (si es necesario)
    }


}
