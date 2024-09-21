using RealEstateManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Interfaces
{
    public interface IOwnerRepository
    {
        void CreateOwner(Owner owner);
        Owner GetOwnerById(int id);
        IEnumerable<Owner> GetOwners();
        void UpdateOwner(Owner owner);
        void DeleteOwner(int id);
    }

}
