using EasyHreg.Backend.Models;
using EasyHreg.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyHreg.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonsController(IDatabaseService databaseService) : ControllerBase
{    
    [HttpGet]
    public Task<ActionResult<IEnumerable<Person>>> GetAll()
    {
        var persons = databaseService.GetPersons();

        return Task.FromResult<ActionResult<IEnumerable<Person>>>(Ok(persons));
    }
}
