namespace Configuratorr.Model
{
    public class IndexerSettings
    {
        public int MinimumSeeders { get; set; } = 1;
        public object seedCriteria { get; set; } = new object();
        public string BaseUrl { get; set; }
        public string ApiPath { get; set; } = "/api";
        public string ApiKey { get; set; }
        public int[] Categories { get; set; } = {5030, 5040};
        public int[] AnimeCategories { get; set; } = {};
    }
}