using PLP_SystemInfo.Models;
using System.Collections.ObjectModel;

namespace PLP_SystemInfo.Collections
{
    public class GraphicsCollection : Collection<GraphicsCard>
    {
        public override string ToString()
        {
            return base.ToString() + " : " + this.Count + " items";
        }
    }
}
