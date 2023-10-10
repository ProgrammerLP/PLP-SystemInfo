using Microsoft.Win32;
using System;
using System.Management;

namespace PLP_SystemInfo
{
    public static class ComponentInfo
    {
        public static string GetOperatingSystemInfo()
        {
            var osn = "";
            var osa = "";

            var mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Caption"] != null)
                {
                    osn = managementObject["Caption"].ToString();   //Display operating system caption
                }

                if (managementObject["OSArchitecture"] != null)
                {
                    osa = managementObject["OSArchitecture"].ToString();   //Display operating system architecture.
                }
            }

            return osn + "(" + osa + ")";
        }

        public static string GetCPUName()
        {
            var processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);

            if (processor_name != null)
            {
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    try
                    {
                        return processor_name.GetValue("ProcessorNameString").ToString();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            return "Error by getting the processor name";
        }

        public static int GetCPUThreads() => Environment.ProcessorCount;

        public static int GetCPUCores()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_Processor");
            int cores = 0;
            foreach (ManagementObject item in mos.Get())
            {
                cores = int.Parse(item["NumberOfCores"].ToString());
            }

            return cores;
        }

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

        public static string GetGraphicscardName()
        {
            string name = "";

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DisplayControllerConfiguration");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    name = queryObj["Name"].ToString();
                }

                return name;

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while querying GPU Name in NuGet Package PLP-SystemInfo: " + e.Message);
                return e.Message;
            }
        }

        public static long GetGraphicscardVRAM()
        {
            long totalVRAM = 0;

            try
            {
                ManagementClass c = new ManagementClass("Win32_VideoController");
                foreach (ManagementObject o in c.GetInstances())
                {
                    string gpuTotalMem = String.Format("{0} ", o["AdapterRam"]);
                    long vram = Convert.ToInt64(gpuTotalMem);
                    Console.WriteLine(vram / 1073741824 + "Gb");
                    totalVRAM = vram / 1073741824;
                }
                return totalVRAM;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while querying GPU VRAM in NuGet Package PLP-SystemInfo: " + e.Message);
                return -1;
            }
        }
    }
}
