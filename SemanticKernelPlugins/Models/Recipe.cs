using System.Text;
using SemanticKernelPlugins.Models.Enums;

namespace SemanticKernelPlugins.Models;

public class Recipe
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<string> Ingredients { get; set; } = [];
    public Difficulty Difficulty { get; set; }


    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"**Recipe:** {Name}");
        stringBuilder.AppendLine($"**Difficulty:** {Difficulty}");
        stringBuilder.AppendLine("**Ingredients:**");

        foreach (var ingredient in Ingredients)
        {
            stringBuilder.AppendLine($"- {ingredient}");
        }

        return stringBuilder.ToString(); ;
    }
}
