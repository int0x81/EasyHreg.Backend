using Microsoft.AspNetCore.Mvc;

namespace EasyHreg.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    [HttpGet]
    public Task<ActionResult<IEnumerable<byte[]>>> GetAll()
    {
        throw new NotImplementedException();
    }
}