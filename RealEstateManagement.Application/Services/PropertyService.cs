using RealEstateManagement.Domain.Entities;
using RealEstateManagement.Domain.Interfaces;

namespace RealEstateManagement.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
      
        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
            
        }

        public IEnumerable<Property> GetProperties()
        {
            return _propertyRepository.GetAllProperties();
        }

        public Property GetPropertyById(int id)
        {
            return _propertyRepository.GetPropertyById(id);
        }

        public bool CreateProperty(Property property)
        {
            var wproperty = new Property
            {
                Name = property.Name,
                Address = property.Address,
                Price = property.Price,
                Year = property.Year,
                IdOwner = property.IdOwner
            };

            return _propertyRepository.CreateProperty(wproperty);
        }


        public bool UpdateProperty(int id, Property property)
        {
            var propertyId = _propertyRepository.GetPropertyById(id);
            if (propertyId == null)
                return false;

            propertyId.Name = property.Name;
            propertyId.Address = property.Address;
            propertyId.Price = property.Price;
            propertyId.Year = property.Year;
            propertyId.IdOwner = property.IdOwner;

            return _propertyRepository.UpdateProperty(propertyId);
        }


        public void DeleteProperty(int id)
        {
            _propertyRepository.DeleteProperty(id);
            _propertyRepository.SaveChanges();
        }

        public void AddImageToProperty(int propertyId, PropertyImage image)
        {
            _propertyRepository.AddImageToProperty(propertyId, image);
            _propertyRepository.SaveChanges();
        }

        public void ChangePrice(int propertyId, PropertyTrace priceTrace)
        {
            _propertyRepository.AddPriceTrace(propertyId, priceTrace);
            _propertyRepository.SaveChanges();
        }

        public IEnumerable<Property> GetPropertiesWithFilters(string address, decimal? minPrice, decimal? maxPrice)
        {
            return _propertyRepository.GetPropertiesWithFilters(address, minPrice, maxPrice);
        }
    }


}


