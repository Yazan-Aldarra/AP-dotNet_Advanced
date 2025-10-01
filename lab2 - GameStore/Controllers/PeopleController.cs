using System.Linq.Expressions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

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
}
