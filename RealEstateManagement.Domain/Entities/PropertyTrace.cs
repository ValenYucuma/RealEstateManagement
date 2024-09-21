using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Entities
{
        public class PropertyTrace
        {
            public int IdPropertyTrace { get; set; }
            public DateTime DateSale { get; set; }  // Fecha de venta.
            public string Name { get; set; }  // Nombre del tipo de precio (por ejemplo, "Precio inicial", "Rebaja").
            public decimal Value { get; set; }  // Valor del precio.
            public decimal Tax { get; set; }  // Impuestos aplicables.

            // Relación con Property
            public int IdProperty { get; set; }
            public Property Property { get; set; }
        }

}


