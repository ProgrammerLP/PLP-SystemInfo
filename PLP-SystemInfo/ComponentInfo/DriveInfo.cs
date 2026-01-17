using PLP_SystemInfo.Models;
using System;
using System.Linq;
using System.Management;

public class DriveInfo
{
    public static DriveDetails GetDriveHardwareInfo(string drivePath)
    {
        char driveLetter = char.ToUpper(drivePath.Trim().First(c => char.IsLetter(c)));

        var scope = new ManagementScope(@"\\localhost\root\Microsoft\Windows\Storage");
        scope.Connect();

        uint diskNumber = 0;
        bool found = false;
        var queryPartition = new ObjectQuery($"SELECT DiskNumber FROM MSFT_Partition WHERE DriveLetter = '{driveLetter}'");

        using (var searcher = new ManagementObjectSearcher(scope, queryPartition))
        {
            var partitionObj = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
            if (partitionObj != null)
            {
                diskNumber = (uint)partitionObj["DiskNumber"];
                found = true;
            }
        }

        if (!found) throw new Exception("Partition für " + driveLetter + " nicht gefunden.");

        var queryDisk = new ObjectQuery($"SELECT * FROM MSFT_PhysicalDisk WHERE DeviceId = '{diskNumber}'");

        using (var searcher = new ManagementObjectSearcher(scope, queryDisk))
        {
            var diskObj = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
            if (diskObj == null) throw new Exception("Physische Disk nicht gefunden.");

            var result = new DriveDetails();
            result.PhysicalDiskId = diskObj["DeviceId"]?.ToString();
            result.Model = diskObj["FriendlyName"]?.ToString();
            result.MediaTypeRaw = Convert.ToInt32(diskObj["MediaType"]);
            result.BusTypeRaw = Convert.ToInt32(diskObj["BusType"]);

            return result;
        }
    }
}