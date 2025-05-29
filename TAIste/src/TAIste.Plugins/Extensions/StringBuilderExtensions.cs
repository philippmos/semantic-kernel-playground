using System.Text;

namespace TAIste.Plugins.Extensions;

public static class StringBuilderExtensions
{
    public static void AppendString(this StringBuilder stringBuilder, string key, string value)
    {
        stringBuilder.Append($"**{key}:** {value}");
    }

    public static void AppendList(this StringBuilder stringBuilder, string key, IEnumerable<string> values)
    {
        stringBuilder.AppendLine($"**{key}:** ");

        foreach (var value in values)
        {
            stringBuilder.AppendLine($"- {value}");
        }
    }
}
