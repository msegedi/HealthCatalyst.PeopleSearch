using System;

namespace HealthCatalyst.Apis.People.Data.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Interests { get; set; } // This might end up being a separate table (Interest) in a production app -- linked via a many-to-many table such as PersonInterest. Depends on business requirements.
        public string PictureFileName { get; set; } // Many ways to accomplish depending on privacy/security requirements.

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; } // This would likely be StateId and tied to a State table in a production app.
        public string Country { get; set; } // This would likely be CountryId and tied to a Country table in a production app.
        public string Zip { get; set; }
    }
}
