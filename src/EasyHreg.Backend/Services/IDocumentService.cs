namespace EasyHreg.Backend.Services;

/// <summary>
/// A file store that is capable of managing documents.
/// </summary>
public interface IDocumentService
{
    /// <summary>
    /// Gets all signed documents from the file store.
    /// </summary>
    Task<IEnumerable<byte[]>> GetSignedDocuments();
    
    /// <summary>
    /// Saves a document in the file store.
    /// </summary>
    Task SaveDocument(byte[] file);
}