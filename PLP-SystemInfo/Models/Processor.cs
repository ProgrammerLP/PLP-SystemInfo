namespace PLP_SystemInfo.Models
{
    public class Processor
    {
        public string Name { get; }
        public string Architecture { get; }
        public int Threads { get; }
        public int Cores { get; }
        public double L2Cache { get; }
        public double L3Cache { get; }
        public double MaxCache { get; }
        public double CrtClockSpeed { get; }
        public double MaxClockSpeed { get; }

        public Processor(string name, string architecture, int threads, int cores, double l2, double l3, double maxCache, double crtClockSpeed, double maxClockSpeed)
        {
            this.Name = name;
            this.Architecture = architecture;
            this.Threads = threads;
            this.Cores = cores;
            this.L2Cache = l2;
            this.L3Cache = l3;
            this.MaxCache = maxCache;
            this.CrtClockSpeed = crtClockSpeed;
            this.MaxClockSpeed = maxClockSpeed;
        }

        public override string ToString()
        {
            return $"{Name} ({Architecture})";
        }
    }
}
