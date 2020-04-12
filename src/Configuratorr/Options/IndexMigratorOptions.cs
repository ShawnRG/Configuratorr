using CommandLine;

namespace Configuratorr.Options
{
    [Verb("migrate-indexers", HelpText = "Migrate indexers from Jackett to Sonarr and/or Radarr")]
    public class IndexMigratorOptions
    {
            [Option("apikey", Required = true, HelpText = "Jackett API key")]
            public string ApiKey { get; set; }

            [Option("jackett", Required = true, HelpText = "Jackett configuration directory")]
            public string JackettDirectory { get; set; }

            [Option("sonarr", Required = true, HelpText = "Sonarr db file")]
            public string SonarrDirectory { get; set; }
            [Option("radarr", Required = true, HelpText = "Radarr db file")]
            public string RadarrDirectory { get; set; }

            [Option("jackettURL", Required = false, HelpText = "Jackett base URL default: localhost:9117", Default = "localhost:9117")]
            public string jackettURL { get; set; }

            [Option('d', "dropcreate", Required = false, HelpText = "Drop all indexers before adding jacket indexers", Default = false)]
            public bool recreate { get; set; }
    }
}