using System;
using System.Collections.Generic;
using System.Text;

namespace WakeUpLanSender.Core
{
    public static class HostInformationRetriever
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostname"></param>
        /// <returns></returns>
        public static IEnumerable<HostInformation> RetrieveFromHostname(string hostname) => RetrieveFromHostnameAsync(hostname).Result;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostname"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        public static async Task<IEnumerable<HostInformation>> RetrieveFromHostnameAsync(string hostname)
        {
            if (hostname == null)
                throw new ArgumentNullException();

            IPAddress[] ipAddresses = await Dns.GetHostAddressesAsync(hostname);



            foreach (var ip in ipAddresses)
            {

            }
        }


        public static async Task<PhysicalAddress> GetPhysicalAddressAsync(IPAddress ip)
        {
            if (ip == null)
                throw new ArgumentNullException();

            Process arp = new Process();
            arp.StartInfo = new ProcessStartInfo()
            {
                FileName = "arp",
                Arguments = "-a " + ip,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            arp.Start();


        }
    }
}
