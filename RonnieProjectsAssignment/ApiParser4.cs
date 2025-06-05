using System.Text.Json;

namespace RonnieProjectsAssignment;

public class ApiParser4 : IApiParser
{
    private const int SourceId = 4;

    public User ParseElement(JsonElement item)
    {
        string firstName = item.GetProperty("first_name").GetString() ?? "";
        string lastName = item.GetProperty("last_name").GetString() ?? "";
        string email = item.GetProperty("email").GetString() ?? "";
        return new User(firstName, lastName, email, SourceId);
    }

    public JsonElement GetListProperty(JsonElement mainJson)
    {
        return mainJson.GetProperty("data");
    }
}