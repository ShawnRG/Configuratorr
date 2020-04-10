using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Configuratorr.IO
{
    public sealed class IndexerPlugin
    {
        public static List<string> GetIndexerNamesFromPath(string jackettPath) {
            var filePaths = Directory.GetFiles(jackettPath, "*.json", SearchOption.TopDirectoryOnly);
            return filePaths
                .Select(s => Path.GetFileNameWithoutExtension(s))
                .ToList();
        }
    }
}