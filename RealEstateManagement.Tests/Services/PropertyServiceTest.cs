using Moq;
using NUnit.Framework;
using RealEstateManagement.Domain.Entities;
using RealEstateManagement.Domain.Interfaces;
using RealEstateManagement.Application.Services;
using System.Collections.Generic;
using Xunit;

namespace RealEstateManagement.Application.Services
{

    using Moq;
    using Xunit;
    using RealEstateManagement.Domain.Interfaces;
    using RealEstateManagement.Domain.Entities;
    using RealEstateManagement.Application.Services;

    public class PropertyServiceTest
    {
        private readonly Mock<IPropertyRepository> _propertyRepositoryMock;
        private readonly PropertyService _propertyService;

        public PropertyServiceTest()
        {
            _propertyRepositoryMock = new Mock<IPropertyRepository>();
            _propertyService = new PropertyService(_propertyRepositoryMock.Object);
        }

        [Fact]
        public void CreateProperty_ShouldCallRepositoryCreateMethod()
        {
            // Arrange
            var property = new Property { IdProperty = 1, Name = "Test Property" };

            // Act
            _propertyService.CreateProperty(property);

            // Assert
            _propertyRepositoryMock.Verify(r => r.CreateProperty(It.IsAny<Property>()), Times.Once);
        }
    }

}

