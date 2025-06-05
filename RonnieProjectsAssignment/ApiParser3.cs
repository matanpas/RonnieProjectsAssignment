using System.Text.Json;

namespace RonnieProjectsAssignment;

public class ApiParser3 : IApiParser
{
    private const int SourceId = 3;

    public User ParseElement(JsonElement item)
    {
        string firstName = item.GetProperty("firstName").GetString() ?? "";
        string lastName = item.GetProperty("lastName").GetString() ?? "";
        string email = item.GetProperty("email").GetString() ?? "";
        return new User(firstName, lastName, email, SourceId);
    }

    public JsonElement GetListProperty(JsonElement mainJson)
    {
        return mainJson.GetProperty("users");
    }
}