using System.Collections.Generic;
using System.CommandLine;
using Resgen.lib;

var typeOption = new Option<string>( new[]{ "--type", "-t" },
        getDefaultValue: () => "types.yml",
        description: "Input type.yml file(s)");
var outputOption = new Option<string>( new[] { "--output", "-o"},
        getDefaultValue: () => ".",
        description: "Output directory");
var fileOption = new Option<List<string>>( new[] {"--result", "-r"},
        () => new() {"cs", "sql"},
        "Output result files, ex: sql, cs, java, etc...");

// Add the options to a root command:
var rootCommand = new RootCommand
{
    typeOption,
    outputOption,
    fileOption
};

rootCommand.Description = "Resource Generator";

rootCommand.SetHandler(async (string t, string o, List<string> f) =>
{
    Options options = new Options() {
        InputFile = t,
        OutputDirectory = o,
        OutputFiles = f  
    };
   
   var service = new GenerateResourcesService(options);
   service.Run();
}, typeOption, outputOption, fileOption);

// Parse the incoming args and invoke the handler
return rootCommand.Invoke(args);