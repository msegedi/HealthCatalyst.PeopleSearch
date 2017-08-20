using HealthCatalyst.Apis.People.Data.Entities;
using HealthCatalyst.Apis.People.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCatalyst.Apis.People.Web.Mappers
{
    public interface IPersonV1Mapper
    {
        Task<IList<PersonV1>> MapFromDataEntities(IList<Person> daPeople);
    }
}
