namespace RonnieProjectsAssignment;

public class User(string firstName, string lastName, string email, int sourceId)
{
    public const string CsvHeader = "FirstName,LastName,Email,SourceId";
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string Email { get; set; } = email;
    public int SourceId { get; set; } = sourceId; // 1-indexed like the list in the instructions
}