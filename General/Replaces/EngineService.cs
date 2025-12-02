using System.Text.RegularExpressions;

namespace General.Replaces;

public class EngineService
{
    private static readonly Regex _regex = new(@"--(?<propName>\w+)--", RegexOptions.Compiled);

    public static string Process<T>(string stringToProcess, T data)
    {
        if (string.IsNullOrEmpty(stringToProcess)) return string.Empty;

        return _regex.Replace(stringToProcess, match =>
        {
            if (PropertyCache<T>.TryGetValue(data, match.Value, out var value))
                return value ?? "";

            return match.Value;
        });
    }
}
