using EasyHreg.Backend.Models;
using EasyHreg.Backend.Services;
using EasyHreg.Backend.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace EasyHreg.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MutationsController(
    // IDatabaseService databaseService, 
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
                            <td>XXX</td>
                        </tr>
                        <tr>
                            <td>Ledigname:</td>
                            <td>XXX</td>
                        </tr>
                        <tr>
                            <td>Vorname(n):</td>
                            <td>XXX</td>
                        </tr>
                        <tr>
                            <td>Geschlecht:</td>
                            <td>XXX</td>
                        </tr>
                        <tr>
                            <td>Heimatort/Staatsangehörigkeit:</td>
                            <td>XXX</td>
                        </tr>
                        <tr>
                            <td>Geburtsdatum:</td>
                            <td>XXX</td>
                        </tr>
                        <tr>
                            <td>Wohnsitz:</td>
                            <td>XXX</td>
                        </tr>
                        <tr>
                            <td>Art, Nummer, Datum und Ausgabebehörde des amtlichen Ausweises:</td>
                            <td>XXX</td>
                        </tr>
                </body>
            </html>";
    }

    [HttpPost]
    public async Task<ActionResult> Post(Mutation mutation)
    {
        // var approvingPersons = await databaseService.GetApprovePersons(mutation);
        var approvingPersons = new List<Person>
        {
            new() {
                Id = 1,
                Email = "bla@tt.com",
                Role = "VR"
            },
            new() {
                Id = 2,
                Email = "blub@tt.com",
                Role = "VR"
            }
        };
            

        foreach(var person in approvingPersons)
        {
            // We act like the documents are signed immediately when the mutation is requested.
            // In reality this would be a more complex process.
            var mockedDocument = CreateSignedDocument(person);
            var pdf = await pdfService.CreatePdfFromHtml(mockedDocument);
            await documentService.SaveDocument(pdf, "XXX.pdf");
        }

        return Ok();
    }
}