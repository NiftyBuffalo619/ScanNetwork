using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Net.NetworkInformation;

namespace ScanNetwork
{
    class netInterfaceSettings : CommandSettings
    {

    }
    class netInterface : Command<netInterfaceSettings>
    {
        public override int Execute([NotNull] CommandContext context, [NotNull] netInterfaceSettings settings)
        {
            try
            {
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                var NetworkTable = new Table();
                NetworkTable.AddColumn("Interface");
                NetworkTable.AddColumn("Description");
                NetworkTable.AddColumn("IPv4 Address");
                NetworkTable.AddColumn("Subnet Mask");
                foreach (NetworkInterface netInterface in networkInterfaces)
                {
                    if (netInterface.OperationalStatus == OperationalStatus.Up)
                    {
                        IPInterfaceProperties ipProperties = netInterface.GetIPProperties();
                        if (ipProperties != null)
                        {
                            foreach (UnicastIPAddressInformation ipInfo in ipProperties.UnicastAddresses)
                            {
                                if (ipInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                {
                                    NetworkTable.AddRow($"{netInterface.Name}", $"{netInterface.Description}", $"{ipInfo.Address}"
                                        , $"{ipInfo.IPv4Mask}");
                                }
                            }
                        }
                    }
                    else
                    {
                        AnsiConsole.MarkupLine($"Interface '{netInterface.Name}' is not connected");
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                AnsiConsole.WriteException(e);
                return 1;
            }
        }
    }
}
