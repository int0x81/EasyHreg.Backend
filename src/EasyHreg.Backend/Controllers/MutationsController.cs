using EasyHreg.Backend.Models;
using EasyHreg.Backend.Services;
using EasyHreg.Backend.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace EasyHreg.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MutationsController(
    IDatabaseService databaseService, 
    IDocumentService documentService,
    PdfService pdfService) : ControllerBase
{
    /// <summary>
    /// Creates a document for the given person.
    /// </summary>
    private static string CreateSignedDocument(Person person)
    {
        return $@"
            <html>
                <body>
                    <h1>Unterschriftsberechtigte Person</h1>
                    <table>
                        <tr>
                            <td>Nachname:</td>
                            <td>{person.LastName}</td>
                        </tr>
                        <tr>
                            <td>Ledigname:</td>
                            <td>{person.UnmarriedName}</td>
                        </tr>
                        <tr>
                            <td>Vorname(n):</td>
                            <td>{person.FirstName}</td>
                        </tr>
                        <tr>
                            <td>Geschlecht:</td>
                            <td>{person.Gender}</td>
                        </tr>
                        <tr>
                            <td>Heimatort/Staatsangehörigkeit:</td>
                            <td>{person.Nationality}</td>
                        </tr>
                        <tr>
                            <td>Geburtsdatum:</td>
                            <td>{person.Birthdate}</td>
                        </tr>
                        <tr>
                            <td>Wohnsitz:</td>
                            <td>{person.Residence}</td>
                        </tr>
                        <tr>
                            <td>Art, Nummer, Datum und Ausgabebehörde des amtlichen Ausweises:</td>
                            <td>{person.OfficialId}</td>
                        </tr>
                </body>
            </html>";
    }

    [HttpPost]
    public async Task<ActionResult> Post(Mutation mutation)
    {
        var approvingPersons = await databaseService.GetApprovePersons(mutation);

        foreach(var person in approvingPersons)
        {
            // We act like the documents are signed immediately when the mutation is requested.
            // In reality this would be a more complex process.
            var mockedDocument = CreateSignedDocument(person);
            var pdf = await pdfService.CreatePdfFromHtml(mockedDocument);
            await documentService.SaveDocument(pdf, $"{person.FirstName}_{person.LastName}.pdf");
        }

        return Ok();
    }
}
