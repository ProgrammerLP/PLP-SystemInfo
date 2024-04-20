using PLP_SystemInfo.Collections;
using System;
using System.Management;
using System.Runtime.InteropServices;

namespace PLP_SystemInfo.ComponentInfo
{
    public class RamInfo
    {
        //Ram
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private class MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;

            public MEMORYSTATUSEX()
            {
                dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);

        private static double ConvertBytesToGB(ulong bytes)
        {
            return Math.Round(bytes / (1024.0 * 1024.0 * 1024.0), 3);
        }

        private static void GetMemoryStatus(out double totalMemoryGB, out double availableMemoryGB)
        {
            var memoryStatus = new MEMORYSTATUSEX();
            if (GlobalMemoryStatusEx(memoryStatus))
            {
                totalMemoryGB = ConvertBytesToGB(memoryStatus.ullTotalPhys);
                availableMemoryGB = ConvertBytesToGB(memoryStatus.ullAvailPhys);
            }
            else
            {
                throw new InvalidOperationException("Failed to retrieve memory status.");
            }
        }

        /// <summary>
        /// Returns a long value of the installed GB of RAM.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the total useable ram in GB.
        /// </summary>
        /// <returns></returns>
        public static double GetTotalUsableRam()
        {
            double memTotal, memAvailable;
            GetMemoryStatus(out memTotal, out memAvailable);
            return memTotal;
        }

        /// <summary>
        /// Returns the harware reserved ram in MB.
        /// </summary>
        /// <returns></returns>
        public static double GetHardwareReservedRam()
        {
            return Math.Round((GetInstalledRAMSize() - GetTotalUsableRam()) * 1000);
        }

        /// <summary>
        /// Returns the used ram in GB.
        /// </summary>
        /// <returns></returns>
        public static double GetRamInUse()
        {
            double memTotal, memAvailable;
            RamInfo.GetMemoryStatus(out memTotal, out memAvailable);
            return memTotal - memAvailable;
        }

        /// <summary>
        /// Returns the available ram.
        /// </summary>
        /// <returns></returns>
        public static double GetAvailableRam()
        {
            double memTotal, memAvailable;
            RamInfo.GetMemoryStatus(out memTotal, out memAvailable);
            return memAvailable;
        }

        /// <summary>
        /// Returns a collection of type **RAM** containing information for each installed ram module such as manufacturer, frequency, voltage and capacity.
        /// </summary>
        /// <returns></returns>
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
