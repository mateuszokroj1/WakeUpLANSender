using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

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
    }
}
