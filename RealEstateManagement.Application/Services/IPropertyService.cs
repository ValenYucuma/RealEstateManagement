using RealEstateManagement.Domain.Entities;


namespace RealEstateManagement.Application.Services
{
    public interface IPropertyService
    {
        IEnumerable<Property> GetProperties();
        Property GetPropertyById(int id);
        bool CreateProperty(Property property);
        bool UpdateProperty(int id, Property property);
        void DeleteProperty(int id);
        void AddImageToProperty(int propertyId, PropertyImage image);
        void ChangePrice(int propertyId, PropertyTrace priceTrace);
        IEnumerable<Property> GetPropertiesWithFilters(string address, decimal? minPrice, decimal? maxPrice);
    }



}
