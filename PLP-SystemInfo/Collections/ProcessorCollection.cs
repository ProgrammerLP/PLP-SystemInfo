using PLP_SystemInfo.Models;
using System.Collections.ObjectModel;

namespace PLP_SystemInfo.Collections
{
    public class ProcessorCollection : Collection<Processor>
    {
        public override string ToString()
        {
            return base.ToString() + " : " + this.Count + " items";
        }
    }
}
