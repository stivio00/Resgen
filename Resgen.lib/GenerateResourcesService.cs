namespace Resgen.lib;

using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Scriban;

public class GenerateResourcesService
{
    private Options _options;
    private IDeserializer _deserializer;

    public GenerateResourcesService(Options options)
    {
        _options = options;
        DeserializerBuilder builder = new();
        _deserializer = builder.Build();
    }

    public void Run()
    {
        LogOptions();
        string inputText = File.ReadAllText(_options.InputFile);
        var types = _deserializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(inputText);

        foreach (string fileType in _options.OutputFiles)
        {
            string templateText = GetTemplateFromFileType(fileType);
            if (templateText == "") continue;

            var template = Template.Parse(templateText);
            var result = template.Render(new { Context = types });

            var path = Path.Combine(_options.OutputDirectory, "output." + fileType);
            File.WriteAllText(path, result);
        }

    }

    private string GetTemplateFromFileType(string fileType) => fileType switch
    {
        "cs" => Resources.CsLiquidTemplate(),
        "sql" => Resources.SqlLiquidTemplate(),
        _ => ""
    };

    private void LogOptions() => Console.WriteLine($"options = {_options}");


}