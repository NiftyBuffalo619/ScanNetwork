using System;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ScanNetwork
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            Console.Title = "ScanNetwork";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var app = new CommandApp();
            app.Configure(config =>
            {
                //config.AddCommand<ScanLocalNetworkCommand>("scanLocal");
                config.AddCommand<netInterface>("netInterface");
            });
            return await app.RunAsync(args);
        }
    }
}
