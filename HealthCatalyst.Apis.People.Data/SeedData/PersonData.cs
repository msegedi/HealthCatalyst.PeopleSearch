using HealthCatalyst.Apis.People.Data.Entities;
using HealthCatalyst.Apis.People.Data.Infrastructure;
using System;

namespace HealthCatalyst.Apis.People.Data.SeedData
{
    public class PersonData
    {
        public static void AddPeople(DatabaseContext db)
        {
            db.People.Add(new Person
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
            });

            db.People.Add(new Person
            {
                FirstName = "Duncan",
                LastName = "Arvizo",
                BirthDate = new DateTime(1986, 7, 9),
                Interests = "chess, checkers",
                PictureFileName = "duncan_arvizo.jpg",
                AddressLine1 = "7588 Wild Rose Lane",
                AddressLine2 = "Apt. 121",
                City = "Eastlake",
                State = "OH",
                Zip = "44095",
                Country = "United States"
            });

            db.People.Add(new Person
            {
                FirstName = "Sherie",
                LastName = "Zweifel",
                BirthDate = new DateTime(1972, 1, 26),
                Interests = "playing cards",
                PictureFileName = "sherie_zweifel.png",
                AddressLine1 = "27 Manor Station Road",
                AddressLine2 = null,
                City = "Neenah",
                State = "WI",
                Zip = "54956",
                Country = "United States"
            });

            db.People.Add(new Person
            {
                FirstName = "Jaunita",
                LastName = "Master",
                BirthDate = new DateTime(1990, 10, 2),
                Interests = "hiking, running",
                PictureFileName = null,
                AddressLine1 = "80 S. Clay Rd.",
                AddressLine2 = null,
                City = "Cambridge",
                State = "MA",
                Zip = "02138",
                Country = "United States"
            });

            db.People.Add(new Person
            {
                FirstName = "Elia",
                LastName = "Mccaughey",
                BirthDate = new DateTime(1967, 7, 15),
                Interests = "video games",
                PictureFileName = "elia_mccaughey.jpeg",
                AddressLine1 = "851 Morris St.",
                AddressLine2 = null,
                City = "Elmhurst",
                State = "NY",
                Zip = "11373",
                Country = "United States"
            });

            db.SaveChanges();
        }

        // Seed method will only be ran once, so I'll leave out the "create if not exists" logic :(
        //        private static void AddPerson(DatabaseContext db, string firstName, string lastName)
        //        {

        //            var sql = $@"
        //IF NOT EXISTS (SELECT *
        //               FROM Person 
        //               WHERE FirstName = @firstName
        //               AND LastName = @lastName)
        //BEGIN
        //    INSERT INTO Person (FirstName, LastName)
        //    VALUES (@firstName, @lastName)
        //END
        //";

        //            var param = new List<SqlParameter>
        //            {
        //                new SqlParameter("@FirstName", firstName),
        //                new SqlParameter("@LastName", lastName)
        //            };

        //            db.Database.ExecuteSqlCommand(sql, param);
        //        }
    }
}
