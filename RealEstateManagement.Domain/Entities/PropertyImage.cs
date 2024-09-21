using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Entities
{
    public class PropertyImage
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public Property Property { get; set; }
        public string File { get; set; }  // Imagen almacenada como bytes.
        public bool Enabled { get; set; }  // Para saber si la imagen está habilitada o no.
    }


}
