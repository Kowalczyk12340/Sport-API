using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SportAPI.Swashbucle
{
  public class EnumTypesSchemaFilter : ISchemaFilter
  {
    private readonly XDocument _xmlComments;

    public EnumTypesSchemaFilter(string xmlPath)
    {
      if (File.Exists(xmlPath))
      {
        _xmlComments = XDocument.Load(xmlPath);
      }
    }

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
      if (_xmlComments == null) return;

      if (schema.Enum == null || schema.Enum.Count <= 0 || !(context.Type is { IsEnum: true }))
      {
        return;
      }

      var enumMemberNameStart = $"F:{context.Type.FullName}";

      var enumMembers = _xmlComments.Descendants("member")
        .Where(x => !(x.Attribute("name") is null) && x.Attribute("name")!.Value.StartsWith(enumMemberNameStart) &&
                    !(x.Descendants("value").FirstOrDefault() is null) &&
                    int.TryParse(x.Descendants("value").First().Value, out _)).ToDictionary(
          k => int.Parse(k.Descendants("value").First().Value),
          v => v.Descendants("summary").FirstOrDefault()?.Value.Trim() ?? "No description");

      if (!enumMembers.Any())
      {
        return;
      }

      var description = new StringBuilder("<p>Members:</p><ul>");

      foreach (var enumMemberValue in schema.Enum.OfType<OpenApiInteger>().Select(v => v.Value))
      {
        var summary = enumMembers.ContainsKey(enumMemberValue) ? enumMembers[enumMemberValue] : "No description";

        description.Append($"<li>[{enumMemberValue}] {summary}</li>");
      }

      description.Append("</ul>");
      schema.Description += description.ToString();
    }
  }
}