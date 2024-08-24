using EasyHreg.Backend.Models;

namespace EasyHreg.Backend.Services;

/// <summary>
/// Provides all functionality to interact with the database.
/// </summary>
public interface IDatabaseService
{
    /// <summary>
    /// Gets all persons from the database.
    /// </summary>
    Task<IEnumerable<Person>> GetPersons();
    
    /// <summary>
    /// Gets all persons that have to approve a mutation.
    /// </summary>
    Task<IEnumerable<Person>> GetApprovePersons(Mutation mutation);
}