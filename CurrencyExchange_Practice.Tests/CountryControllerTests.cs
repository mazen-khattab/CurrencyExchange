using AutoMapper;
using CurrencyExchange_Practice.API.Controllers;
using CurrencyExchange_Practice.Application.Services;
using CurrencyExchange_Practice.Core.Entities;
using CurrencyExchange_Practice.Core.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CurrencyExchange_Practice.Tests
{
    public class CountryControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResultWithCountries()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var countryService = new CountryService(mockUnitOfWork.Object);
            var expectedCountries = new List<Country>
            {
                new Country { Id = 1, CountryName = "USA", CurrencyId = 1 },
                new Country { Id = 2, CountryName = "Canada", CurrencyId = 1 }
            };

            mockCountryService.Setup(service => service.GetAll(false)).ReturnsAsync(expectedCountries);

            var controller = new CountryController(mockCountryService.Object, mockMapper.Object);

            // Act 
            var result = await controller.Getall();

            // Assert 
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCountries = Assert.IsType<List<Country>>(okResult.Value);
            Assert.Equal(expectedCountries.Count, returnedCountries.Count);
        }
    }
}
