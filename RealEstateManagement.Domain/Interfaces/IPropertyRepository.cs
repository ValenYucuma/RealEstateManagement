using RealEstateManagement.Domain.Entities;

namespace RealEstateManagement.Domain.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAllProperties();
        Property GetPropertyById(int id);
        bool CreateProperty(Property property);
        bool UpdateProperty(Property property);
        void DeleteProperty(int id);
        void AddImageToProperty(int propertyId, PropertyImage image);
        void AddPriceTrace(int propertyId, PropertyTrace priceTrace);
        IEnumerable<Property> GetPropertiesWithFilters(string address, decimal? minPrice, decimal? maxPrice);
        void SaveChanges();
    }


}
