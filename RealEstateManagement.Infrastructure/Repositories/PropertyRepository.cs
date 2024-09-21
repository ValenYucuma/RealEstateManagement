using RealEstateManagement.Domain.Entities;
using RealEstateManagement.Domain.Interfaces;
using RealEstateManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class PropertyRepository : IPropertyRepository
{
    private readonly RealEstateContext _context;

    public PropertyRepository(RealEstateContext context)
    {
        _context = context;
    }

    public IEnumerable<Property> GetAllProperties()
    {
        return _context.Properties.Include(p => p.Owner).ToList();
    }

    public Property GetPropertyById(int id)
    {
        return _context.Properties
            .Include(p => p.Owner)
            .Include(p => p.PropertyImages)
            .Include(p => p.PropertyPrices)
            .FirstOrDefault(p => p.IdProperty == id);
    }

    public bool CreateProperty(Property property)
    {
        _context.Properties.Add(property);
        return _context.SaveChanges() > 0; // Retornamos un bool que indica si la operación fue exitosa
    }



    public bool UpdateProperty(Property property)
    {
        var existingProperty = _context.Properties.FirstOrDefault(p => p.IdProperty == property.IdProperty);

        if (existingProperty != null)
        {
            existingProperty.Name = property.Name;
            existingProperty.Address = property.Address;
            existingProperty.Price = property.Price;
            existingProperty.Year = property.Year;
            existingProperty.IdOwner = property.IdOwner;

            _context.Properties.Update(existingProperty);
            return _context.SaveChanges() > 0;
        }

        return false;
    }


    public void DeleteProperty(int id)
    {
        var property = GetPropertyById(id);
        if (property != null)
        {
            _context.Properties.Remove(property);
        }
    }

    public void AddImageToProperty(int propertyId, PropertyImage image)
    {
        var property = GetPropertyById(propertyId);
        if (property != null)
        {
            property.PropertyImages.Add(image);
        }
    }

    public void AddPriceTrace(int propertyId, PropertyTrace priceTrace)
    {
        var property = GetPropertyById(propertyId);
        if (property != null)
        {
            property.PropertyPrices.Add(priceTrace);
        }
    }

    public IEnumerable<Property> GetPropertiesWithFilters(string address, decimal? minPrice, decimal? maxPrice)
    {
        var query = _context.Properties.AsQueryable();

        if (!string.IsNullOrEmpty(address))
        {
            query = query.Where(p => p.Address.Contains(address));
        }

        if (minPrice.HasValue)
        {
            query = query.Where(p => p.Price >= minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= maxPrice.Value);
        }

        return query.Include(p => p.Owner).ToList();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
