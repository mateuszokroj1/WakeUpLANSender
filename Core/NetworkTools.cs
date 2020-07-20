using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WakeUpLanSender.Core
{
    public static class NetworkTools
    {
        public static async Task<bool> RunPingAsync(IPAddress ipAddress)
        {
            if (ipAddress == null)
                throw new ArgumentNullException();

            Process ping = new Process();
            ping.StartInfo = new ProcessStartInfo
            {
                FileName = "ping",
                Arguments = "/n 4 " + ipAddress,
                CreateNoWindow = false,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            ping.Start();

            string output = await ping.StandardOutput.ReadToEndAsync();
            ping.Close();

            string[] words = Regex.Split(output, @"\W");
            return words
                .Where(word => string.Equals(word, "Reply", StringComparison.InvariantCultureIgnoreCase))
                .Count() == 4;
        }

        public static async Task<PhysicalAddress> RunArpAsync(IPAddress ipAddress)
        {
            Process arp = new Process();
            arp.StartInfo = new ProcessStartInfo()
            {
                FileName = "arp",
                Arguments = "-a " + ipAddress,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            arp.Start();
        }
    }
}
