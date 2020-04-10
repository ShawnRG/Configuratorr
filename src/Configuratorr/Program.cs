using CommandLine;

namespace Configuratorr
{
    public class Program
    {
        public class Options
        {

            [Option("apikey", Required = true, HelpText = "Jackett API key")]
            public string ApiKey { get; set; }

            [Option("jackett", Required = true, HelpText = "Jackett root directory")]
            public string JackettDirectory { get; set; }
        }

        public static Options Arguments { get; private set; }
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(runOptions);
        }

        static void runOptions(Options options)
        {
            Arguments = options;
        }
    }
}