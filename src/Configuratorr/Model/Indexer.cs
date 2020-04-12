namespace Configuratorr.Model
{
    public class Indexer
    {
        public string Name { get; set; }
        public IndexerSettings Settings { get; set; } = new IndexerSettings();
        public string Implementation { get; set; } = "Torznab";
        public string ConfigContract { get; set; } = "TorznabSettings";
        public int EnableRss { get; set; } = 1;
        public int EnableAutomaticSearch { get; set; } = 1;
        public int EnableInteractiveSearch { get; set; } = 1;
        

    }

}