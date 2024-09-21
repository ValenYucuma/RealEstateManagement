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
    public class OwnerRepository : IOwnerRepository
    {
        private readonly RealEstateContext _context;

        public OwnerRepository(RealEstateContext context)
        {
            _context = context;
        }

        public void CreateOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.Find(id);
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public void UpdateOwner(Owner owner)
        {
            //_context.Entry(owner).State = EntityState.Modified;
            //_context.SaveChanges();
        }

        public void DeleteOwner(int id)
        {
            var owner = GetOwnerById(id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                _context.SaveChanges();
            }
        }
    }

}
