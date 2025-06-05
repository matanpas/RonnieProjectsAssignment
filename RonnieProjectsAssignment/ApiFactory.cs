namespace RonnieProjectsAssignment;

public static class ApiFactory
{
    private static readonly string[] Urls =
    [
        "https://randomuser.me/api/?results=500",
        "https://jsonplaceholder.typicode.com/users",
        "https://dummyjson.com/users",
        "https://reqres.in/api/users"
    ];

    public static Dictionary<string, IApiParser> GetDictionary()
    {
        return new Dictionary<string, IApiParser>
        {
            [Urls[0]] = new ApiParser1(),
            [Urls[1]] = new ApiParser2(),
            [Urls[2]] = new ApiParser3(),
            [Urls[3]] = new ApiParser4()
        };
    }
}