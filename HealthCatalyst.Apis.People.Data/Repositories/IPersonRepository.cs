using HealthCatalyst.Apis.People.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCatalyst.Apis.People.Data.Repositories
{
    public interface IPersonRepository
    {
        Task<IList<Person>> SearchByName(string name);
    }
}
