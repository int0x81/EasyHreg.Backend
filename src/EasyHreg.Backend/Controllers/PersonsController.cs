using EasyHreg.Backend.Models;
using EasyHreg.Backend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EasyHreg.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonsController(IDatabaseService databaseService) : ControllerBase
{    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> GetAll()
    {
        var persons = await databaseService.GetPersons();

        return Ok(persons);
    }
}
