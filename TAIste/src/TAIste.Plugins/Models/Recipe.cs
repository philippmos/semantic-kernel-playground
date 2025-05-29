using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TAIste.Plugins.Extensions;
using TAIste.Plugins.Models.Enums;

namespace TAIste.Plugins.Models;

public class Recipe
{
    [BsonId]
    [BsonElement("_id")]
    public ObjectId ObjectId { get; set; }

    [BsonElement("id")]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("ingredients")]
    public IEnumerable<string> Ingredients { get; set; } = [];

    [BsonElement("instructions")]
    public IEnumerable<string> Instructions { get; set; } = [];

    [BsonElement("servings")]
    public int Servings { get; set; }

    [BsonElement("cuisine")]
    public string Cuisine { get; set; } = string.Empty;

    [BsonElement("difficulty")]
    public Difficulty Difficulty { get; set; }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendString(nameof(Name), Name);
        stringBuilder.AppendString(nameof(Cuisine), Cuisine);
        stringBuilder.AppendString(nameof(Difficulty), Difficulty.ToString());
        stringBuilder.AppendString(nameof(Servings), Servings.ToString());

        stringBuilder.AppendList(nameof(Ingredients), Ingredients);
        stringBuilder.AppendList(nameof(Instructions), Instructions);

        return stringBuilder.ToString();
    }
}
