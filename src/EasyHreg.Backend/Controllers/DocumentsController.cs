using EasyHreg.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyHreg.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController(IDocumentService documentService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<byte[]>>> GetAll()
    {
        var documents = await documentService.GetSignedDocuments();
        return Ok(documents);
    }
}