using PLP_SystemInfo;
using PLP_SystemInfo.ComponentInfo;
using PLP_SystemInfo.Models;
using System.Windows;

namespace PLP_SystemInfoTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            list.Items.Add("SystemInfos");
            list.Items.Add(SystemInfo.MachineName);
            list.Items.Add(SystemInfo.UserName);
            list.Items.Add(SystemInfo.GetWindowsAccentColor());
            list.Items.Add(SystemInfo.IsDarkModeEnabled);
            list.Items.Add("");
            list.Items.Add("OS");
            list.Items.Add(OSInfo.GetOperatingSystemInfo());
            list.Items.Add("Board");
            var board = BoardInfo.GetMotherboard();
            list.Items.Add(board.ToString());
            list.Items.Add("BIOS");
            var bios = BoardInfo.GetBIOSInfo();
            list.Items.Add(bios.ToString());
            foreach (var item in GraphicsInfo.GetGraphicscardInfo())
            {
                list.Items.Add("Graphics");
                list.Items.Add(item.ToString());
            }
            foreach (var item in RamInfo.GetRamInfo())
            {
                list.Items.Add("Ram Module");
                list.Items.Add(item.ToString());
            }
            foreach (var item in ProcessorInfo.GetProcessors())
            {
                list.Items.Add("Processors");
                list.Items.Add(item.ToString());
            }

            list.Items.Add(ProcessorInfo.GetProcessors().ToString());
            list.Items.Add(RamInfo.GetRamInfo().ToString());
            list.Items.Add(GraphicsInfo.GetGraphicscardInfo().ToString());

            list.Items.Add(RamInfo.GetTotalUsableRam());
            list.Items.Add(RamInfo.GetAvailableRam());
            list.Items.Add(RamInfo.GetRamInUse());
            list.Items.Add(RamInfo.GetHardwareReservedRam());

            DriveDetails info = DriveInfo.GetDriveHardwareInfo("C");
            list.Items.Add("Drive C:");
            list.Items.Add($"Physische Disk ID: {info.PhysicalDiskId}");
            list.Items.Add($"Modell Name:       {info.Model}");
            list.Items.Add($"Medien-Typ:        Code: {info.MediaType}");
            list.Items.Add($"Bus-Typ:           {info.BusType}");

            DriveDetails info2 = DriveInfo.GetDriveHardwareInfo("D");
            list.Items.Add("Drive D:");
            list.Items.Add($"Physische Disk ID: {info2.PhysicalDiskId}");
            list.Items.Add($"Modell Name:       {info2.Model}");
            list.Items.Add($"Medien-Typ:        Code: {info2.MediaType}");
            list.Items.Add($"Bus-Typ:           {info2.BusType}");

            DriveDetails info3 = DriveInfo.GetDriveHardwareInfo("E");
            list.Items.Add("Drive E:");
            list.Items.Add($"Physische Disk ID: {info3.PhysicalDiskId}");
            list.Items.Add($"Modell Name:       {info3.Model}");
            list.Items.Add($"Medien-Typ:        Code: {info3.MediaType}");
            list.Items.Add($"Bus-Typ:           {info3.BusType}");
        }
    }
}