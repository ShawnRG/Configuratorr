using Configuratorr.Options;

namespace Configuratorr.Model
{
    public static class IndexerFactory
    {
        public static Indexer Create(string name, IndexMigratorOptions options) {
            var settings = new IndexerSettings{
                baseUrl = $"http://{options.jackettURL}/api/v2.O/indexers/{name}/results/torznab/",
                apiKey = options.ApiKey
            };

            return new Indexer{
                Name = name,
                Settings = settings
            };
        }
    }
}