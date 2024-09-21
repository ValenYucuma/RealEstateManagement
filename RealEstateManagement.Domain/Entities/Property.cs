using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Entities
{
    public class Property
    {
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }

        // Relación con Owner
        public int IdOwner { get; set; }
        public Owner Owner { get; set; }

        // Propiedades de navegación
        public ICollection<PropertyImage> PropertyImages { get; set; }  // Una propiedad puede tener varias imágenes.
        public ICollection<PropertyTrace> PropertyPrices { get; set; }  // Una propiedad puede tener varios precios asociados.
    }



}
