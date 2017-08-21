using HealthCatalyst.Apis.People.Data.Entities;
using HealthCatalyst.Apis.People.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCatalyst.Apis.People.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DatabaseContext _db;

        public PersonRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<IList<Person>> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            // Note, need to properly escape %.
            // Also note, a production-level search implementation would probably use full-text index searching or Lucene, etc.
            var query = _db.People
                .Where(p => EF.Functions.Like(p.FirstName, $"%{name}%") || EF.Functions.Like(p.LastName, $"%{name}%"))
                .OrderBy(p => p.LastName); // ToDo: Sorting is really a UI concern, or at least should be supported at the API level via request params and not assumed to be by last name.

            return await query.ToListAsync();
        }
    }
}
