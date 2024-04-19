using PLP_SystemInfo.Collections;
using System;
using System.Management;

namespace PLP_SystemInfo.ComponentInfo
{
    public class RamInfo
    {
        //Ram
        public static long GetInstalledRAMSize()
        {
            var oMs = new ManagementScope();
            var oQuery = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
            var oSearcher = new ManagementObjectSearcher(oMs, oQuery);
            var oCollection = oSearcher.Get();

            long memSize = 0;
            long mCap = 0;

            // In case more than one Memory sticks are installed
            foreach (ManagementObject obj in oCollection)
            {
                mCap = Convert.ToInt64(obj["Capacity"]);
                memSize += mCap;
            }

            memSize /= 1073741824;

            return memSize;
        }

        public static long GetTotalUsableRam()
        {
            throw new NotImplementedException();
        }

        public static long GetRamInUse()
        {
            throw new NotImplementedException();
        }

        public static long GetAvailableRam()
        {
            throw new NotImplementedException();
        }

        public static RamCollection GetRamInfo()
        {
            RamCollection rams = new RamCollection();

            ConnectionOptions connection = new ConnectionOptions();
            connection.Impersonation = ImpersonationLevel.Impersonate;
            ManagementScope scope = new ManagementScope("\\\\.\\root\\CIMV2", connection);
            scope.Connect();
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            foreach (ManagementObject queryObj in searcher.Get())
            {
                rams.Add(new Models.RAM(queryObj["Manufacturer"].ToString(), queryObj["ConfiguredClockSpeed"] + " MT/s", double.Parse(queryObj["ConfiguredVoltage"].ToString()) / 1000d, Convert.ToInt64(queryObj["Capacity"].ToString()) / 1073741824));
            }

            return rams;
        }
    }
}
