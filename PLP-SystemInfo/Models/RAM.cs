namespace PLP_SystemInfo.Models
{
    public class RAM
    {
        public string Manufacturer { get; }
        public string Frequency { get; }
        public double Voltage { get; }
        public long Size { get; }

        public RAM(string manufacturer, string frequency, double voltage, long size)
        {
            this.Manufacturer = manufacturer;
            this.Frequency = frequency;
            this.Voltage = voltage;
            this.Size = size;
        }

        public override string ToString()
        {
            return $"{Manufacturer} {Size}GB {Frequency}";
        }
    }
}
