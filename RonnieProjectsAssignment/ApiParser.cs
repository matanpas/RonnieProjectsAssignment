using System.Text.Json;

namespace RonnieProjectsAssignment;

public interface IApiParser
{
    public User ParseElement(JsonElement item);
    public JsonElement GetListProperty(JsonElement mainJson);
}