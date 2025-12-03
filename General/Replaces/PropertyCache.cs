namespace General.Replaces;

using System.Linq.Expressions;
using System.Reflection;

public static class PropertyCache<T>
{
    private static readonly Dictionary<string, Func<T, string>> _getters;
    public static readonly IEnumerable<string> AvailableKeys;

    static PropertyCache()
    {
        _getters = new Dictionary<string, Func<T, string>>(StringComparer.OrdinalIgnoreCase);
        var keysList = new List<string>();

        foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!prop.CanRead) continue;

            var parameter = Expression.Parameter(typeof(T), "x");
            var propertyAccess = Expression.Property(parameter, prop);

            Expression conversion = Expression.Call(
                typeof(Convert),
                nameof(Convert.ToString),
                null,
                Expression.Convert(propertyAccess, typeof(object))
            );

            var lambda = Expression.Lambda<Func<T, string>>(conversion, parameter).Compile();

            var keyName = $"--{prop.Name.ToUpper()}--";

            _getters[keyName] = lambda;
            keysList.Add(keyName);
        };

        AvailableKeys = keysList;
    }

    public static bool TryGetValue(T instance, string key, out string value)
    {
        if (_getters.TryGetValue(key, out var getter))
        {
            value = getter(instance);
            return true;
        }
        value = null;
        return false;
    }
}