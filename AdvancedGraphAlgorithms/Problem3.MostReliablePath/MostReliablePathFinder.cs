namespace Problem3.MostReliablePath
{
    using System.Collections.Generic;
    using System;
    using System.Globalization;
    using System.Threading;

    public static class MostReliablePathFinder
    {
        public static string GetMostReliablePath(
            int[,] graph, int sourceNode, int destinationNode)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var path = MostReliablePathFinder.FindMostReliablePath(
                graph, sourceNode, destinationNode);

            if (path == null)
            {
                return "no path";
            }
            else
            {
                double pathLength = graph[path[0], path[1]] / 100d;
                for (int i = 1; i < path.Count - 1; i++)
                {
                    var doubleValue = Convert.ToDouble(
                        graph[path[i], path[i + 1]]);
                    var valueInPersentage = doubleValue/100d;
                    pathLength = pathLength * valueInPersentage;
                }

                pathLength *= 100;
                pathLength = Math.Round(pathLength, 2);

                var formattedPath = string.Join(" -> ", path);
                var result =
                    $"Most reliable path reliability: {pathLength}%" +
                    Environment.NewLine + formattedPath;
                return result;
            }
        }

        private static List<int> FindMostReliablePath(
            int[,] graph, int sourceNode, int destinationNode)
        {
            int n = graph.GetLength(0);
            int[] distance = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MinValue;
            }

            distance[sourceNode] = 0;

            var used = new bool[n];
            int?[] previous = new int?[n];
            while (true)
            {
                int minDistance = int.MinValue;
                int minNode = 0;
                for (int node = 0; node < n; node++)
                {
                    if (!used[node] && distance[node] > minDistance)
                    {
                        minDistance = distance[node];
                        minNode = node;
                    }
                }

                if (minDistance == int.MinValue)
                {
                    break;
                }

                used[minNode] = true;

                for (int i = 0; i < n; i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        var newDistance = minDistance +
                            (graph[minNode, i]);
                        if ((newDistance > distance[i]) &&
                            !used[i])
                        {
                            distance[i] = newDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            if (distance[destinationNode] == int.MinValue)
            {
                return null;
            }

            var path = new List<int>();
            int? currentNode = destinationNode;
            previous[sourceNode] = null;
            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }

            path.Reverse();
            return path;
        }
    }
}
