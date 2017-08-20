using HealthCatalyst.Apis.People.Data.Infrastructure;
using HealthCatalyst.Apis.People.Data.SeedData;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCatalyst.Apis.People.Data.Migrations
{
    public partial class SeedPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            PersonData.AddPeople(new DatabaseContext());
        }
    }
}
