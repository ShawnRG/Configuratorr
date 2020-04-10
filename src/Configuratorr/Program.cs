using System;
using System.IO;
using CommandLine;
using Configuratorr.IO;
using Configuratorr.Options;
using Microsoft.Data.Sqlite;

namespace Configuratorr
{
    public class Program
    {

        static void Main(string[] args)
        {
            try {
                CommandLine.Parser.Default.ParseArguments<IndexMigratorOptions>(args)
                    .MapResult(
                        IndexerMigrator.run,
                        errors => 1
                    );
            } catch (Exception e) {
                Console.WriteLine($"ERROR: {e.Message}");
                Environment.ExitCode = 1;
            }

        }
    }
}