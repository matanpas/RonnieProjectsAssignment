namespace RonnieProjectsAssignment;

public static class ApiFactory
{
    public static Dictionary<string, IApiParser> GetDictionary()
    {
        return new Dictionary<string, IApiParser>
        {
            ["https://randomuser.me/api/?results=500"] = new ApiParser1(),
            ["https://jsonplaceholder.typicode.com/users"] = new ApiParser2(),
            ["https://dummyjson.com/users"] = new ApiParser3(),
            ["https://reqres.in/api/users"] = new ApiParser4()
        };
    }
}