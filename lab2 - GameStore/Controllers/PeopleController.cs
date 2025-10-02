using System.Linq.Expressions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace lab2___GameStore;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private AppDbContext context;

    public PeopleController(AppDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var res = context.People;
        return Ok(res);
    }
    [HttpPost]
    public IActionResult AddOne([FromBody] Person p)
    {
        context.People.Add(p);
        context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteOne(int id)
    {
        var p = context.People.Find(id);

        if (p == null)
            return NotFound();
    
        context.People.Remove(p);
        context.SaveChanges();
        return NoContent();
    }
    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        return Ok(context.People.Find(id));
    }
    [HttpPut("{id}")]
    public IActionResult UpdateOne(int id, [FromBody] Person updatedP)
    {
        var p = context.People.Find(id);
        if (p == null)
            return NotFound();
        UpdatePerson(p, updatedP);

        context.SaveChanges();
        return NoContent();
    }
    private void UpdatePerson(Person p, Person updatedP)
    {
        p.FirstName = updatedP.FirstName;
        p.LastName = updatedP.LastName;
        p.Gender = updatedP.Gender;
        p.Email = updatedP.Email;
    }
}
