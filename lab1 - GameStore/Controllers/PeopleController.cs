using GameStore.Models;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NuGet.DependencyResolver;
using NuGet.Protocol;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private static List<Person> people = new List<Person>
        {
            new Person { Id = 1, FirstName = "Alice", LastName = "Johnson", Gender = Gender.Female, Email = "alice.johnson@example.com", PhoneNumber = "555-1234" },
            new Person { Id = 2, FirstName = "Bob", LastName = "Smith", Gender = Gender.Male, Email = "bob.smith@example.com", PhoneNumber = "555-2345" },
            new Person { Id = 3, FirstName = "Charlie", LastName = "Brown", Gender = Gender.Male, Email = "charlie.brown@example.com", PhoneNumber = "555-3456" },
            new Person { Id = 4, FirstName = "Diana", LastName = "Miller", Gender = Gender.Female, Email = "diana.miller@example.com", PhoneNumber = "555-4567" },
            new Person { Id = 5, FirstName = "Ethan", LastName = "Davis", Gender = Gender.Male, Email = "ethan.davis@example.com", PhoneNumber = "555-5678" }
        };

        public PeopleController()
        {

        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] int? id)
        {
            if (id != null)
            {
                var p = people.Find(p => p.Id == id);
                if (p != null)
                    return Ok(p);
                else
                    return NotFound("Person doesn't exist");
            }
            return Ok(people);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Person p)
        {
            people.Add(p);
            return Created();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById(int id, [FromHeader(Name = "X-AccessKey")] string key)
        {
            if (key != "123456789")
                return Unauthorized();
            var p = people.Find(p => p.Id == id);
            if (p != null)
            {
                people.Remove(p);
                return NoContent();
            }
            return NotFound("The person doesn't exist");
        }
        [HttpPost]
        public IActionResult UpdatePerson([FromBody] Person p)
        {
            int index = people.FindIndex(el => el.Id == p.Id);
            if (index == -1)
                return NotFound();
            people[index] = p;
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(people.Find(p => p.Id == id));
        }
        [HttpGet]
        [Route("{lastName}")]
        public IActionResult GetById(string lastName)
        {
            return Ok(people.Find(p => p.LastName == lastName));
        }
    }
}
