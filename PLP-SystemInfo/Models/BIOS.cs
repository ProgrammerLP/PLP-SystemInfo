namespace PLP_SystemInfo.Models
{
    public class BIOS
    {
        public string Manufacturer { get; }
        public string VersionName { get; }
        public string Version { get; }

        public BIOS(string manufacturer, string versionName, string version)
        {
            this.Manufacturer = manufacturer;
            this.VersionName = versionName;
            this.Version = version;
        }

        public override string ToString()
        {
            return $"{Manufacturer} {VersionName}";
        }
    }
}
