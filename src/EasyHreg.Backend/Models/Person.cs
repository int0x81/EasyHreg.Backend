namespace EasyHreg.Backend.Models;

public record Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string UnmarriedName { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.Other;
    public string Nationality { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; }
    public string Residence { get; set; } = string.Empty;
    public string OfficialId { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}