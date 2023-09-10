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
using Spectre.Console;

namespace ScanNetwork
{
    class ScanLocalNetworkCommandSettings : CommandSettings
    {
        
    }
    class ScanLocalNetworkCommand : Command<ScanLocalNetworkCommandSettings>
    {
        public override int Execute([NotNull] CommandContext context, [NotNull] ScanLocalNetworkCommandSettings settings)
        {
            var SubnetMask = AnsiConsole.Ask<string>("What's the subnet mask ?");
            Ping ping;
            IPAddress IP;
            PingReply Reply;
            IPHostEntry Entry;
            string name;

            Parallel.For(0, 254, (i, loopState) => {
                ping = new Ping();
                Reply = ping.Send(i.ToString());

                if (Reply.Status == IPStatus.Success)
                {
                    try
                    {
                        IP = IPAddress.Parse(SubnetMask);
                        Entry = Dns.GetHostEntry(IP);
                        name = Entry.HostName;
                        AnsiConsole.MarkupLine($"{IP} {Entry} {name}");
                    }
                    catch (Exception e)
                    {

                    }
                }
            });
            
            return 0;
        }
    }
}
