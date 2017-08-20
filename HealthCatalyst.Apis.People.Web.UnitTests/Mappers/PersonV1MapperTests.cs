using HealthCatalyst.Apis.People.Data.Entities;
using HealthCatalyst.Apis.People.Web.Exceptions;
using HealthCatalyst.Apis.People.Web.Mappers;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HealthCatalyst.Apis.People.Web.UnitTests.Mappers
{
    public class PersonV1MapperTests
    {
        [Fact]
        public async Task MapFromDataEntities_throws_exception_when_null_list_supplied()
        {
            // Arrange
            var settings = new AppSettings { PersonPictureBaseUrl = "http://test.com/" };
            var optionsSettings = new Mock<IOptions<AppSettings>>();
            optionsSettings.SetupGet(s => s.Value).Returns(settings);
            var mapper = new PersonV1Mapper(optionsSettings.Object);

            // Act & Assert
            await Assert.ThrowsAsync<NullListException>(async () =>
            {
                await mapper.MapFromDataEntities(null);
            });
        }

        [Fact]
        public async Task MapFromDataEntities_returns_correctly_mapped_person()
        {
            // Arrange
            var settings = new AppSettings { PersonPictureBaseUrl = "http://test.com/" };
            var optionsSettings = new Mock<IOptions<AppSettings>>();
            optionsSettings.SetupGet(s => s.Value).Returns(settings);
            var mapper = new PersonV1Mapper(optionsSettings.Object);

            var daPeople = new List<Person>
            {
                new Person
                {
                    FirstName = "Frederick",
                    LastName = "Arjona",
                    BirthDate = new DateTime(1980, 3, 12),
                    Interests = "snowboarding, board games",
                    PictureFileName = "fred_arjona.jpg",
                    AddressLine1 = "7096 Clinton Ave.",
                    AddressLine2 = null,
                    City = "West Islip",
                    State = "NY",
                    Zip = "11795",
                    Country = "United States"
                }
            };

            // Act
            var people = await mapper.MapFromDataEntities(daPeople);

            // Assert
            Assert.NotNull(people);
            Assert.Equal(1, people.Count);
            var testPerson = people.Single();
            Assert.Equal("Frederick", testPerson.FirstName);
            Assert.Equal("Arjona", testPerson.LastName);
            Assert.Equal(new DateTime(1980, 3, 12), testPerson.BirthDate);
            Assert.Equal("snowboarding, board games", testPerson.Interests);
            Assert.Equal("http://test.com/fred_arjona.jpg", testPerson.PictureUrl);
            Assert.Equal("7096 Clinton Ave.", testPerson.AddressLine1);
            Assert.Equal(null, testPerson.AddressLine2);
            Assert.Equal("West Islip", testPerson.City);
            Assert.Equal("NY", testPerson.State);
            Assert.Equal("11795", testPerson.Zip);
            Assert.Equal("United States", testPerson.Country);
        }
    }
}
