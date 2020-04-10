using System;
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
        [Fact]
        public void GetIndexerNamesFromFilePath() {
            Assert.NotEmpty(IndexerPlugin.GetIndexerNamesFromPath(jackettPath));
        }
    }
}