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

            [Option("sonarr", Required = true, HelpText = "Sonarr configuration directory")]
            public string SonarrDirectory { get; set; }
            [Option("radarr", Required = true, HelpText = "Radarr configuration directory")]
            public string RadarrDirectory { get; set; }

            [Option("jackettURL", Required = false, HelpText = "Jackett base URL default: localhost:9117", Default = "localhost:9117")]
            public string jackettURL { get; set; }
    }
}