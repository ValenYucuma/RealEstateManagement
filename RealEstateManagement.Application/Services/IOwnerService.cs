using RealEstateManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Services
{
    public interface IOwnerService
    {
        void CreateOwner(Owner owner);
        Owner GetOwnerById(int id);
        IEnumerable<Owner> GetOwners();
        void UpdateOwner(Owner owner);
        void DeleteOwner(int id);
    }

}
