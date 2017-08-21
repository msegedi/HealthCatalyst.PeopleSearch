using HealthCatalyst.Apis.People.Data.Repositories;
using HealthCatalyst.Apis.People.Web.Mappers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthCatalyst.Apis.People.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/people")]
    [EnableCors("AllowAny")]
    public class PeopleV1Controller : Controller
    {
        private readonly IPersonRepository _personRepo;
        private readonly IPersonV1Mapper _personMapper;

        public PeopleV1Controller(
            IPersonRepository personRepo,
            IPersonV1Mapper personMapper)
        {
            _personRepo = personRepo;
            _personMapper = personMapper;
        }

        [HttpGet("searchByName/{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest(new { errorCode = 40100, message = $"'{nameof(name)}' is required." });

            var daPeople = await _personRepo.SearchByName(name);

            var people = await _personMapper.MapFromDataEntities(daPeople);

            // Fake slow searching :)
            System.Threading.Thread.Sleep(5000);

            return Ok(people);
        }
    }
}