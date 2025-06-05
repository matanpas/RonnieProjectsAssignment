using System.Text.Json;

namespace RonnieProjectsAssignment;

public class ApiParser2 : IApiParser
{
    private const int SourceId = 2;

    public User ParseElement(JsonElement item)
    {
        string fullName = item.GetProperty("name").GetString() ?? "";
        var (firstName, lastName) = ParseName(fullName);
        string email = item.GetProperty("email").GetString() ?? "";
        return new User(firstName, lastName, email, SourceId);
    }

    public JsonElement GetListProperty(JsonElement mainJson)
    {
        return mainJson;
    }

    private static (string FirstName, string LastName) ParseName(string fullName)
    {
        HashSet<string> titles = ["Mr.", "Mrs.", "Ms.", "Miss", "Dr.", "Prof."];
        List<string> words = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        if (words.Count == 0)
        {
            return ("", "");
        }

        if (titles.Contains(words[0]))
        {
            words.RemoveAt(0); // Remove the title
        }

        if (words.Count == 1)
        {
            return (words[0], "");
        }

        // reached here, we have at least two names not including the title.
        // We will treat the first name as FirstName and everything else as LastName
        string firstName = words[0];
        string lastName = string.Join(' ', words.Skip(1)); // everything else
        return (firstName, lastName);
    }
}