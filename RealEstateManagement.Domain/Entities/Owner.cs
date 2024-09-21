using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Entities
{
    public class Owner
    {
        public int IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }  // Si quieres guardar la foto como bytes.
        public DateTime Birthday { get; set; }

        // Propiedades de navegación
        public ICollection<Property> Properties { get; set; } // Un dueño puede tener varias propiedades.
    }


}
