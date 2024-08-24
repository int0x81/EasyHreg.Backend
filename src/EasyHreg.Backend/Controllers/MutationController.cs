using EasyHreg.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyHreg.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MutationsController : ControllerBase
{
    [HttpPost]
    public Task<ActionResult> Post(Mutation mutation)
    {
        throw new NotImplementedException();
    }
}