using HealthCatalyst.Apis.People.Web.IntegrationTests.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace HealthCatalyst.Apis.People.Web.IntegrationTests.Controllers
{
    public class PeopleV1ControllerTests
    {
        [Fact]
        public async Task SearchByName_returns_correct_results()
        {
            // Arrange
            var searchString = "fred";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51299/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var fullUrl = "api/v1/people/searchByName/" + searchString;

                var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);

                // Act
                var response = await client.SendAsync(request);

                // Assert
                Assert.True(response.IsSuccessStatusCode);
                var people = JsonConvert.DeserializeObject<IList<PersonV1>>(await response.Content.ReadAsStringAsync());
                Assert.NotNull(people);
                Assert.Equal(1, people.Count);
                var testPerson = people.Single();
                Assert.Equal("Frederick", testPerson.FirstName);
                Assert.Equal("Arjona", testPerson.LastName);
                Assert.Equal(new DateTime(1980, 3, 12), testPerson.BirthDate);
                Assert.Equal("snowboarding, board games", testPerson.Interests);
                Assert.Equal("http://localhost:53527/person_pictures/fred_arjona.jpg", testPerson.PictureUrl);
                Assert.Equal("7096 Clinton Ave.", testPerson.AddressLine1);
                Assert.Equal(null, testPerson.AddressLine2);
                Assert.Equal("West Islip", testPerson.City);
                Assert.Equal("NY", testPerson.State);
                Assert.Equal("11795", testPerson.Zip);
                Assert.Equal("United States", testPerson.Country);
            }
        }

        // ToDo: Integration tests for failure cases.
    }
}
