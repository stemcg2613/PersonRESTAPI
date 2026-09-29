using Microsoft.AspNetCore.Mvc;
using PersonRESTAPI.DataAccess;
using PersonRESTAPI.Models;

namespace PersonRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonDataAccess _personData;

        public PersonController()
        {
            _personData = new PersonDataAccess();
        }

        // GET: api/Person
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _personData.GetPeople();
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody] Person person)
        {
            _personData.SavePerson(person);
        }
    }
}