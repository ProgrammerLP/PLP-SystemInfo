namespace PLP_SystemInfo.Models
{
    public class GraphicsCard
    {
        public string Name { get; }
        public string DriverVersion { get; }

        public GraphicsCard(string name, string driverVersion)
        {
            this.Name = name;
            this.DriverVersion = driverVersion;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
