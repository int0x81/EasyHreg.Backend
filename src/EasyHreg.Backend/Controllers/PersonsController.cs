using EasyHreg.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyHreg.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    [HttpGet]
    public Task<ActionResult<IEnumerable<Person>>> GetAll()
    {
        throw new NotImplementedException();
    }
}
