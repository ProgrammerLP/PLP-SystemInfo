namespace PLP_SystemInfo.Models
{
    public class Board
    {
        public string Manufacturer { get; }
        public string Model { get; }

        public Board(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public override string ToString()
        {
            return $"{Manufacturer} {Model}";
        }
    }
}
