using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Configuratorr;
using Configuratorr.IO;
using Moq;
using Xunit;
using Microsoft.Data.Sqlite;

namespace ConfiguratorrTests
{
    public class IndexerTests
    {
        private static readonly string baseResourcesPath = AppDomain.CurrentDomain.BaseDirectory + "/Resources/";
        private static readonly string jackettPath = baseResourcesPath + "Jackett/Indexers";
        private static readonly string sonarrDBPath = baseResourcesPath + "sonarr.db";
        private static readonly string radarrDBPath = baseResourcesPath + "radarr.db";
        private static readonly List<string> indexerNames = new List<string>() {"1337x", "badasstorrents", "thepiratebay", "rarbg", "ettv"};
        [Fact]
        public void GetIndexerNamesFromFilePath() {
            var indexers = IndexerPlugin.GetIndexerNamesFromPath(jackettPath);
            Assert.NotEmpty(indexers);
            Assert.False(indexerNames.Except(indexers).Any());
        }

        [Fact]
        public void TestInsertingIndexersIntoSonarr()
        {
            TestMigration(sonarrDBPath);
        }

        [Fact]
        public void TestInsertingIndexersIntoRadarr()
        {
            TestMigration(radarrDBPath);
        }

        private static void TestMigration(string dbFile)
        {
            var indexers = IndexerPlugin.GetIndexerNamesFromPath(jackettPath);
            var tempDb = Path.GetTempPath() + Guid.NewGuid().ToString() + ".db";
            File.Copy(dbFile, tempDb);
            IndexerMigrator.MigrateIndexers(indexers, tempDb);
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = tempDb;

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT COUNT(*) FROM Indexers;";

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var count = reader.GetInt32(0);
                        Assert.Equal(6, count);
                    }
                }
            }

            File.Delete(tempDb);
        }
    }
}