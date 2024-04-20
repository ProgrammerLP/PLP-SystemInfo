using PLP_SystemInfo.Collections;
using System;
using System.Management;

namespace PLP_SystemInfo.ComponentInfo
{
    public class GraphicsInfo
    {
        /// <summary>
        /// Returns a collection of type **GraphicsCard** containing information such as name and driver version.
        /// </summary>
        /// <returns></returns>
        public static GraphicsCollection GetGraphicscardInfo()
        {
            GraphicsCollection graphics = new GraphicsCollection();

            try
            {
                ManagementClass c = new ManagementClass("Win32_VideoController");
                foreach (ManagementObject o in c.GetInstances())
                {
                    graphics.Add(new Models.GraphicsCard(o["Name"].ToString(), o["DriverVersion"].ToString()));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            }

            return graphics;
        }
    }
}
