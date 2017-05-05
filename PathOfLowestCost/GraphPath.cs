using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathOfLowestCost
{
    public class GraphPath
    {
        public int Cost { get; set; }
        public bool Finished { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public List<int> RowsVisited { get; set; }
    }
}
