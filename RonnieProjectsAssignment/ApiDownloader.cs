using System.Text.Json;

namespace RonnieProjectsAssignment;

public class ApiDownloader
{
    private static readonly HttpClient HttpClient = new HttpClient();

    public static async Task<JsonElement> Download(string url)
    {
        var response = await HttpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        using var jsonDoc = JsonDocument.Parse(jsonString);
        return jsonDoc.RootElement.Clone();
    }
}