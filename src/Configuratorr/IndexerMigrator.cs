using System.Linq;
using System.IO;
using Configuratorr.IO;
using Configuratorr.Options;
using Microsoft.Data.Sqlite;
using Configuratorr.Model;
using System;
using System.Collections.Generic;

namespace Configuratorr
{
    public class IndexerMigrator
    {
        public static int run(IndexMigratorOptions options)
        {
            var indexerNames = IndexerPlugin.GetIndexerNamesFromPath(options.JackettDirectory);

            MigrateIndexers(indexerNames, options.SonarrDirectory, options);
            MigrateIndexers(indexerNames, options.RadarrDirectory, options);
            return 0;
        }

        public static void MigrateIndexers(List<string> indexerNames, string dbPath, IndexMigratorOptions options)
        {
            Console.WriteLine($"Started migration into ({dbPath})");
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = dbPath;

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {

                    var commandText = $"INSERT INTO Indexers (Name, \"Implementation\", Settings, ConfigContract, EnableRss, EnableAutomaticSearch, EnableInteractiveSearch) "
                     + $"VALUES(@Name, @Implementation, @Settings, @ConfigContract, @EnableRss, @EnableAS, @EnableIS);";
                    var cmd = connection.CreateCommand();
                    if (options.recreate) {
                        Console.WriteLine("Recreation enabled: Dropping all indexers");
                        cmd.CommandText = "DELETE FROM Indexers;";
                        var size = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Deleted {size} indexers");
                    }
                    cmd.CommandText = commandText;
                    indexerNames.Select(name => IndexerFactory.Create(name, options)).ToList()
                        .ForEach(InsertIndexer(cmd));

                    transaction.Commit();

                }
            }
        }

        private static Action<Indexer> InsertIndexer(SqliteCommand cmd)
        {
            return indexer =>
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", indexer.Name);
                cmd.Parameters.AddWithValue("@Implementation", indexer.Implementation);
                cmd.Parameters.AddWithValue("@Settings", Newtonsoft.Json.JsonConvert.SerializeObject(indexer.Settings));
                cmd.Parameters.AddWithValue("@ConfigContract", indexer.ConfigContract);
                cmd.Parameters.AddWithValue("@EnableRss", indexer.EnableRss);
                cmd.Parameters.AddWithValue("@EnableAS", indexer.EnableAutomaticSearch);
                cmd.Parameters.AddWithValue("@EnableIS", indexer.EnableInteractiveSearch);
                var result = 0;
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (SqliteException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine($"Adding indexer ({indexer.Name})".PadRight(40)
                                    + $"{(result == 1 ? "succeeded" : "failed")}");
                }

            };
        }
    }
}