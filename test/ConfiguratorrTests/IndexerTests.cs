using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Configuratorr;
using Configuratorr.IO;
using Moq;
using Xunit;

namespace ConfiguratorrTests
{
    public class IndexerTests
    {
        private static readonly string jackettPath = AppDomain.CurrentDomain.BaseDirectory + "/Resources/Jackett/Indexers";
        private static readonly List<string> indexerNames = new List<string>() {"1337x", "badasstorrents", "thepiratebay", "rarbg", "ettv"};
        [Fact]
        public void GetIndexerNamesFromFilePath() {
            var indexers = IndexerPlugin.GetIndexerNamesFromPath(jackettPath);
            Assert.NotEmpty(indexers);
            Assert.False(indexerNames.Except(indexers).Any());
        }
    }
}