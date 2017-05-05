using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace PathOfLowestCost
{
    public class SumGraph
    {
        private List<List<int>> graph = new List<List<int>>();
        private SimplePriorityQueue<GraphPath> paths = new SimplePriorityQueue<GraphPath>();

        public void AddRow(string integers)
        {
            var numbers = integers.Split(' ').Select(int.Parse);
            graph.Add(new List<int>(numbers));
        }

        public GraphPath GetShortestPath()
        {
            AddFirstColToPaths();
            while (paths.Any())
            {
                var path = paths.Dequeue();
                if (path.Finished)
                    return path;
                try
                {
                    AddChildPaths(path);
                }
                catch (SumTooBigException exception)
                {
                    if(paths.First.Cost > 50)
                        return exception.GraphPath;
                }
            }
            throw new Exception();
        }

        private void AddFirstColToPaths()
        {
            for (var row = 0; row < graph.Count; row++)
            {
                paths.Enqueue(new GraphPath()
                {
                    Column = 0,
                    Row = row,
                    Cost = graph[row][0],
                    RowsVisited = new List<int>() { row + 1}
                }, graph[row][0]);
            }
        }

        private void AddChildPaths(GraphPath path)
        {
            var topDiagonal = GetTopDiagonalPath(path);
            var straight = GetStraightPath(path);
            var bottomDiagonal = GetBottomDiagonalPath(path);
            
            if(topDiagonal.Cost > 50 && straight.Cost > 50 && bottomDiagonal.Cost > 50)
                throw new SumTooBigException(path);

            paths.Enqueue(topDiagonal, topDiagonal.Cost);
            paths.Enqueue(straight, straight.Cost);
            paths.Enqueue(bottomDiagonal, bottomDiagonal.Cost);
        }

        private GraphPath GetTopDiagonalPath(GraphPath path)
        {
            var targetRow = path.Row > 0 ? path.Row - 1 : graph.Count - 1;
            var child = new GraphPath()
            {
                Row = targetRow,
                Column = path.Column + 1,
                Cost = path.Cost + graph[targetRow][path.Column + 1],
                RowsVisited = new List<int>(path.RowsVisited)
            };
            child.RowsVisited.Add(child.Row + 1);

            if (child.Column == graph[path.Row].Count - 1)
                child.Finished = true;

            return child;
        }

        private GraphPath GetStraightPath(GraphPath path)
        {
            var child = new GraphPath()
            {
                Row = path.Row,
                Column = path.Column + 1,
                Cost = path.Cost + graph[path.Row][path.Column + 1],
                RowsVisited = new List<int>(path.RowsVisited)
            };
            child.RowsVisited.Add(child.Row + 1);

            if (child.Column == graph[path.Row].Count - 1)
                child.Finished = true;

            return child;
        }

        private GraphPath GetBottomDiagonalPath(GraphPath path)
        {
            var targetRow = path.Row < graph.Count - 1 ? path.Row + 1 : 0;
            var child = new GraphPath()
            {
                Row = targetRow,
                Column = path.Column + 1,
                Cost = path.Cost + graph[targetRow][path.Column + 1],
                RowsVisited = new List<int>(path.RowsVisited)
            };
            child.RowsVisited.Add(child.Row + 1);

            if (child.Column == graph[path.Row].Count - 1)
                child.Finished = true;

            return child;
        }

    }
}
