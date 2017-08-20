using HealthCatalyst.Apis.People.Data.Entities;
using HealthCatalyst.Apis.People.Web.Exceptions;
using HealthCatalyst.Apis.People.Web.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCatalyst.Apis.People.Web.Mappers
{
    public class PersonV1Mapper : IPersonV1Mapper
    {
        private readonly AppSettings _settings;

        public PersonV1Mapper(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<IList<PersonV1>> MapFromDataEntities(IList<Person> daPeople)
        {
            if (daPeople == null)
                throw new NullListException();

            return daPeople.Select(MapFromDataEntity).ToList();
        }

        private PersonV1 MapFromDataEntity(Person daPerson)
        {
            return new PersonV1
            {
                Id = daPerson.Id,
                FirstName = daPerson.FirstName,
                LastName = daPerson.LastName,
                BirthDate = daPerson.BirthDate,
                Interests = daPerson.Interests,
                PictureUrl = daPerson.PictureFileName == null ? null : _settings.PersonPictureBaseUrl + daPerson.PictureFileName,
                AddressLine1 = daPerson.AddressLine1,
                AddressLine2 = daPerson.AddressLine2,
                City = daPerson.City,
                State = daPerson.State,
                Zip = daPerson.Zip,
                Country = daPerson.Country
            };
        }
    }
}
