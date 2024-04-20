using System.Management;

namespace PLP_SystemInfo.ComponentInfo
{
    public class OSInfo
    {
        /// <summary>
        /// Returns a string with OS name and architecture.
        /// </summary>
        /// <returns></returns>
        public static string GetOperatingSystemInfo()
        {
            string osa = "";
            string osv = "";

            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Caption"] != null)
                {
                    osv = managementObject["Caption"].ToString();
                }
                if (managementObject["OSArchitecture"] != null)
                {
                    osa = managementObject["OSArchitecture"].ToString();
                }
            }

            return $"{osv} ({osa})";
        }
    }
}
