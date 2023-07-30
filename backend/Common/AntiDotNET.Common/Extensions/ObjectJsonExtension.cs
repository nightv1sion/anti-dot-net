using System.Text.Json;

namespace AntiDotNET.Common.Extensions;

public static class ObjectJsonExtension
{
    public static string ToPrettyJson(this object model)
    {
        return JsonSerializer.Serialize(model, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }
}