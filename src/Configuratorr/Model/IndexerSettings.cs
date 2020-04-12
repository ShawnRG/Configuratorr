namespace Configuratorr.Model
{
    public class IndexerSettings
    {
        public int minimumSeeders { get; set; } = 1;
        public object seedCriteria { get; set; } = new object();
        public string baseUrl { get; set; }
        public string apiPath { get; set; } = "/api";
        public string apiKey { get; set; }
        public int[] categories { get; set; } = {5030, 5040};
        public int[] animeCategories { get; set; } = {};
    }
}