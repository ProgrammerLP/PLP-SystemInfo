using PLP_SystemInfo.Models;
using System.Management;

namespace PLP_SystemInfo.ComponentInfo
{
    public class BoardInfo
    {
        /// <summary>
        /// Returns an object of type **Board** with manufacturer and model.
        /// </summary>
        /// <returns></returns>
        public static Board GetMotherboard()
        {
            string manufacturer = "";
            string model = "";

            ManagementClass mgc = new ManagementClass("Win32_BaseBoard");
            foreach (ManagementObject o in mgc.GetInstances())
            {
                manufacturer = o["Manufacturer"].ToString();
                model = o["Product"].ToString();
            }

            return new Board(manufacturer, model);
        }

        /// <summary>
        /// Returns an object of type **BIOS** with manufacturer and version.
        /// </summary>
        /// <returns></returns>
        public static BIOS GetBIOSInfo()
        {
            string manufacturer = "";
            string versionName = "";
            string version = "";

            ManagementClass mc = new ManagementClass("Win32_BIOS");
            foreach (ManagementObject o in mc.GetInstances())
            {
                versionName = o["Name"].ToString();
                version = o["SystemBiosMajorVersion"].ToString() + "." + o["SystemBiosMinorVersion"].ToString();
                manufacturer = o["Manufacturer"].ToString();
            }

            return new BIOS(manufacturer, versionName, version);
        }
    }
}
