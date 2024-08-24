
namespace EasyHreg.Backend.Services.Implementations;

public class FileService : IDocumentService
{
    static string _documentsPath = Path.Combine(Directory.GetCurrentDirectory(), "Documents");
    
    public async Task<IEnumerable<byte[]>> GetSignedDocuments()
    {
        var files = Directory.GetFiles(_documentsPath, "*.pdf");
        var documents = new List<byte[]>();

        foreach (var file in files)
        {
            var fileBytes = await File.ReadAllBytesAsync(file);
            documents.Add(fileBytes);
        }

        return documents;
    }

    public Task SaveDocument(byte[] file, string fileName)
    {
        // Ensure the directory exists
        Directory.CreateDirectory(_documentsPath);
        
        var filePath = Path.Combine(_documentsPath, fileName);
        return File.WriteAllBytesAsync(filePath, file);
    }
}