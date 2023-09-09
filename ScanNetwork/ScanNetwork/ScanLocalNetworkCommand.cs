using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console.Cli;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;

namespace ScanNetwork
{
    class ScanLocalNetworkCommandSettings : CommandSettings
    {
        
    }
    class ScanLocalNetworkCommand : Command<ScanLocalNetworkCommandSettings>
    {
        public override int Execute([NotNull] CommandContext context, [NotNull] ScanLocalNetworkCommandSettings settings)
        {
            Ping ping;
            IPAddress IP;
            PingReply Reply;
            IPHostEntry Entry;
            
            return 0;
        }
    }
}
