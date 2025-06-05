using System.Text;
using System.Text.Json;

namespace RonnieProjectsAssignment;

internal static class PullData
{
    private static readonly string[] AllowedFormats = ["json", "csv"];

    private static string InputValidPath()

    {
        Console.WriteLine("Enter folder path");
        string? path = Console.ReadLine();
        try
        {
            return Path.GetFullPath(path!);
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid Path. Try again");
            return InputValidPath();
        }
    }

    private static string InputValidFormat()
    {
        while (true)
        {
            Console.WriteLine("Enter format (JSON/CSV):");
            string? inputFormat = Console.ReadLine();
            if (inputFormat == null)
            {
                Console.WriteLine("Invalid format. Try again:");
                continue;
            }

            foreach (var format in AllowedFormats)
            {
                if (inputFormat.Equals(format, StringComparison.OrdinalIgnoreCase))
                {
                    return format;
                }
            }

            Console.WriteLine("Invalid format. Try again");
        }
    }

    private static async Task Main(string[] args)
    {
        string folderPath = InputValidPath();
        string format = InputValidFormat();
        Dictionary<string, IApiParser> apiDictionary = ApiFactory.GetDictionary();
        List<User> users = [];
        var csv = new StringBuilder();
        csv.AppendLine(User.CsvHeader);
        foreach (var (url, parser) in apiDictionary)
        {
            var data = await ApiDownloader.Download(url);
            foreach (var item in parser.GetListProperty(data).EnumerateArray())
            {
                User user = parser.ParseElement(item);
                users.Add(user);
                csv.AppendLine($"{user.FirstName},{user.LastName},{user.Email},{user.SourceId}");
            }
        }

        string fullPath;
        switch (format)
        {
            case "csv":
            {
                fullPath = Path.Combine(folderPath, "data.csv");
                await File.WriteAllTextAsync(fullPath, csv.ToString());
                break;
            }
            case "json":
            {
                fullPath = Path.Combine(folderPath, "data.json");
                var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(fullPath, json);
                break;
            }
        }
        Console.WriteLine("done.");
    }
}