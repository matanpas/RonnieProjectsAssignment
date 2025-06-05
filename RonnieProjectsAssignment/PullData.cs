namespace RonnieProjectsAssignment;

internal static class PullData
{
    private static readonly string[] AllowedFormats = ["json", "csv"];

    private static readonly string[] Apis =
    [
        "https://randomuser.me/api/?results=500",
        "https://jsonplaceholder.typicode.com/users",
        "https://dummyjson.com/users",
        "https://reqres.in/api/users"
    ];

    static string InputValidPath()

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

    static string InputValidFormat()
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

    static void Main(string[] args)
    {
        string fullPath = InputValidPath();
        string format = InputValidFormat();
    }
}