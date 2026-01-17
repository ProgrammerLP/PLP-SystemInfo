using System;
using System.Collections.Generic;
using System.Text;

namespace PLP_SystemInfo.Models
{
    public class DriveDetails
    {
        public string PhysicalDiskId { get; set; }
        public string Model { get; set; }
        public int MediaTypeRaw { get; set; }
        public int BusTypeRaw { get; set; }

        public bool IsSSD
        {
            get { return MediaTypeRaw == 4; }
        }

        public string MediaType
        {
            get
            {
                switch (MediaTypeRaw)
                {
                    case 3:
                        return "HDD";
                    case 4:
                        return "SSD";
                    case 5:
                        return "SCM (Storage Class Memory)";
                    case 0:
                        return "Unspecified (Oft USB/Virtuell)";
                    default:
                        return "Unbekannt (" + MediaTypeRaw + ")";
                }
            }
        }

        public string BusType
        {
            get
            {
                switch (BusTypeRaw)
                {
                    case 7:
                        return "USB";
                    case 8:
                        return "RAID";
                    case 11:
                        return "SATA";
                    case 17:
                        return "NVMe";
                    default:
                        return "Andere (" + BusTypeRaw + ")";
                }
            }
        }
    }
}
