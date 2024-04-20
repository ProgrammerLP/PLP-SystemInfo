using PLP_SystemInfo.Collections;
using System;
using System.Collections.ObjectModel;
using System.Management;

namespace PLP_SystemInfo.ComponentInfo
{
    public class ProcessorInfo
    {
        //Processor
        static string GetProcessorArchitecture(int i)
        {
            switch (i)
            {
                case 0:
                    return "x86";
                case 1:
                    return "MIPS";
                case 2:
                    return "Alpha";
                case 3:
                    return "PowerPC";
                case 5:
                    return "ARM";
                case 6:
                    return "ia64";
                case 9:
                    return "x64";
                case 12:
                    return "ARM64";
                default: return "unknown";
            }
        }

        static Collection<double> GetCacheSize()
        {
            Collection<double> result = new Collection<double>();

            ManagementClass mgmtc = new ManagementClass("Win32_CacheMemory");
            foreach (ManagementObject o in mgmtc.GetInstances())
            {
                double max = double.Parse(o["MaxCacheSize"].ToString()) / 1024d;
                result.Add(max);
            }

            return result;
        }

        /// <summary>
        /// Returns a collection of type **Processor** containing information such as name, architecture, cores, threads, cache and clock speed.
        /// </summary>
        /// <returns></returns>
        public static ProcessorCollection GetProcessors()
        {
            ProcessorCollection processors = new ProcessorCollection();
            Collection<double> result = GetCacheSize();

            int i = -1;
            foreach (var item in new ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                i++;
                processors.Add(new Models.Processor(
                    item["Name"].ToString(),
                    GetProcessorArchitecture(int.Parse(item["Architecture"].ToString())),
                    Environment.ProcessorCount,
                    int.Parse(item["NumberOfCores"].ToString()),
                    double.Parse(item["L2CacheSize"].ToString()) / 1024d,
                    double.Parse(item["L3CacheSize"].ToString()) / 1024d,
                    result[i],
                    double.Parse(item["CurrentClockSpeed"].ToString()) / 1000d,
                    double.Parse(item["MaxClockSpeed"].ToString()) / 1000d));
            }

            return processors;
        }
    }
}
