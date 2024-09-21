using RealEstateManagement.Domain.Entities;
using RealEstateManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public void CreateOwner(Owner owner)
        {
            _ownerRepository.CreateOwner(owner);
        }

        public Owner GetOwnerById(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _ownerRepository.GetOwners();
        }

        public void UpdateOwner(Owner owner)
        {
            _ownerRepository.UpdateOwner(owner);
        }

        public void DeleteOwner(int id)
        {
            _ownerRepository.DeleteOwner(id);
        }
    }

}
