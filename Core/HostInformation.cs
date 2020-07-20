using System;
using System.Collections.Generic;
using System.Text;

namespace WakeUpLanSender.Core
{
    public class HostInformation
    {
        public string Name { get; set; }
        public PhysicalAddress Mac { get; set; }
        public IPAddress IpAddress { get; set; }
    }
}
