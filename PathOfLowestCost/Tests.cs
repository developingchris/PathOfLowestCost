using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PathOfLowestCost
{
    public class Tests
    {
        [Fact]
        public void Case1()
        {
            var sumGraph = new SumGraph();
            sumGraph.AddRow("3 4 1 2 8 6");
            sumGraph.AddRow("6 1 8 2 7 4");
            sumGraph.AddRow("5 9 3 9 9 5");
            sumGraph.AddRow("8 4 1 3 2 6");
            sumGraph.AddRow("3 7 2 8 6 4");

            var result = sumGraph.GetShortestPath();

            Assert.True(result.Finished);
            Assert.Equal(16, result.Cost);
            Assert.Equal("1 2 3 4 4 5", string.Join(" ", result.RowsVisited));
        }

        [Fact]
        public void Case2()
        {
            var sumGraph = new SumGraph();
            sumGraph.AddRow("3 4 1 2 8 6");
            sumGraph.AddRow("6 1 8 2 7 4");
            sumGraph.AddRow("5 9 3 9 9 5");
            sumGraph.AddRow("8 4 1 3 2 6");
            sumGraph.AddRow("3 7 2 1 2 3");

            var result = sumGraph.GetShortestPath();

            Assert.True(result.Finished);
            Assert.Equal(11, result.Cost);
            Assert.Equal("1 2 1 5 4 5", string.Join(" ", result.RowsVisited));
        }

        [Fact]
        public void Case3()
        {
            var sumGraph = new SumGraph();
            sumGraph.AddRow("19 10 19 10 19");
            sumGraph.AddRow("21 23 20 19 12");
            sumGraph.AddRow("20 12 20 11 10");

            var result = sumGraph.GetShortestPath();

            Assert.False(result.Finished);
            Assert.Equal(50, result.Cost);
            Assert.Equal("2 1 1", string.Join(" ", result.RowsVisited));
        }

    }
}
