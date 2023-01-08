using System.Text.Json;

namespace Laraue.Apps.LearnLanguage.Common;

public class RoutePathBuilder
{
    private readonly string _routePattern;
    private readonly Lazy<Dictionary<string, string?>> _queryParameters = new (() => new Dictionary<string, string?>());

    public RoutePathBuilder(string routePattern)
    {
        _routePattern = routePattern;
    }

    public string BuildFor(Action<RoutePathBuilder> action)
    {
        var newBuilder = Copy();

        action(newBuilder);

        return newBuilder.ToString();
    }

    private RoutePathBuilder Copy()
    {
        var builder = new RoutePathBuilder(_routePattern);

        if (_queryParameters.IsValueCreated)
        {
            foreach (var (key, value) in _queryParameters.Value)
            {
                builder._queryParameters.Value[key] = value;
            }
        }

        return builder;
    }

    public RoutePathBuilder WithQueryParameter(string parameterName, object value)
    {
        _queryParameters.Value[parameterName] = JsonSerializer.Serialize(value);

        return this;
    }

    public static implicit operator string(RoutePathBuilder builder) => builder.ToString();

    public override string ToString()
    {
        var result = _routePattern;

        if (!_queryParameters.IsValueCreated)
        {
            return result;
        }
        
        var queryParamsParts = _queryParameters.Value.Keys
            .Select(key => $"{key}={_queryParameters.Value[key]}");

        result = $"{result}?{string.Join('&', queryParamsParts)}";

        return result;
    }
}