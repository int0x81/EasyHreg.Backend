namespace EasyHreg.Backend.Models;

/// <summary>
/// Describes a request to a person affecting mutation in the commercial register.
/// </summary>
public record Mutation
{
    /// <summary>
    /// The Id of the person who is affected by the mutation.
    /// </summary>
    public int PersonId { get; set; }
}