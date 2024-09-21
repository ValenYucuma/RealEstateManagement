using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateManagement.Application.Services;
using RealEstateManagement.Domain.Entities;

namespace RealEstateManagement.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        private readonly IAuthService _authService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        
        [HttpGet("GetPropertiesWithFilters")]
        public IActionResult GetProperties([FromQuery] string address, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var properties = _propertyService.GetPropertiesWithFilters(address, minPrice, maxPrice);
            return Ok(properties);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetPropertyById(int id)
        {
            var property = _propertyService.GetPropertyById(id);
            if (property == null)
                return NotFound();

            return Ok(property);
        }

        
        [HttpPost("CreateProperty")]
        public IActionResult CreateProperty([FromBody] Property property)
        {
            var result = _propertyService.CreateProperty(property);
            if (result)
                return Ok("Propiedad creada con éxito.");
            else
                return BadRequest("Error al crear la propiedad.");
        }

      
        [HttpPut("{id}/UpdateProperty")]
        public IActionResult UpdateProperty(int id, [FromBody] Property property)
        {
            var result = _propertyService.UpdateProperty(id, property);
            if (result)
                return Ok("Propiedad actualizada con éxito.");
            else
                return BadRequest("Error al actualizar la propiedad.");
        }


        
        [HttpPost("{propertyId}/AddImageToProperty")]
        public IActionResult AddImageToProperty(int propertyId, [FromBody] PropertyImage image)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _propertyService.AddImageToProperty(propertyId, image);
            return NoContent();
        }
        
        [HttpPost("{propertyId}/ChangePrice")]
        public IActionResult ChangePrice(int propertyId, [FromBody] PropertyTrace priceTrace)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _propertyService.ChangePrice(propertyId, priceTrace);
            return NoContent();
        }

        
    }
}
