using System.Text.Json;

namespace RonnieProjectsAssignment;

public interface IApiParser
{
    public Entity ParseElement(JsonElement element);
}