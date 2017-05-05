using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathOfLowestCost
{
    public class SumTooBigException :Exception
    {
        public GraphPath GraphPath;

        public SumTooBigException(GraphPath graphPath)
        {
            GraphPath = graphPath;
        }
    }
}
