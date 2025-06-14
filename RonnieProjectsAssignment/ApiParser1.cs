﻿using System.Text.Json;

namespace RonnieProjectsAssignment;

public class ApiParser1 : IApiParser
{
    private const int SourceId = 1;

    public User ParseElement(JsonElement item)
    {
        string firstName = item.GetProperty("name").GetProperty("first").GetString() ?? "";
        string lastName = item.GetProperty("name").GetProperty("last").GetString() ?? "";
        string email = item.GetProperty("email").GetString() ?? "";
        return new User(firstName, lastName, email, SourceId);
    }

    public JsonElement GetListProperty(JsonElement mainJson)
    {
        return mainJson.GetProperty("results");
    }
}