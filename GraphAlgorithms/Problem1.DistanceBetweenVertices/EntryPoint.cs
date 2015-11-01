namespace Problem1.DistanceBetweenVertices
{
    using System.Collections.Generic;
    using System;

    public class EntryPoint
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visitedNodes;
        private static int currentDistance;
        private static List<int[]> vertices;

        public static void Main()
        {
            graph = new Dictionary<int, List<int>>()
            {
                { 11, new List<int>() { 4 } },
                { 4, new List<int>() { 12, 1 } },
                { 1, new List<int>() { 12, 21, 7 } },
                { 7, new List<int>() { 21 } },
                { 12, new List<int>() { 4, 19 } },
                { 19,  new List<int>() { 1, 21 } },
                { 21, new List<int>() { 14, 31 } },
                { 14, new List<int>() { 14 } },
                { 31, new List<int>() {  } }
            };

            vertices = new List<int[]>()
            {
                new []{ 11,  7 },
                new []{ 11, 21},
                new []{ 21, 4 },
                new []{ 19, 14 },
                new [] { 1, 4 },
                new [] { 1, 11},
                new []{ 31, 21},
                new []{ 11, 14}
            };

            foreach (var pair in vertices)
            {
                visitedNodes = new HashSet<int>();
                currentDistance = -1;
                Console.WriteLine(FindDistanceBetweenVertices(pair[0], pair[1]));
            }
        }

        public static int FindDistanceBetweenVertices(int start, int end)
        {
            var nodes = new Queue<int>();
            var visited = new HashSet<int>();
            var endVerticeReached = false;
            nodes.Enqueue(start);
            var parents = new Dictionary<int, int>();
            while (nodes.Count != 0)
            {
                int currentNode = nodes.Dequeue();
            
                foreach (var childNode in graph[currentNode])
                {
                    if (!parents.ContainsKey(childNode))
                    {
                        parents.Add(childNode, currentNode);
                    }
                    
                    if (childNode == end)
                    {
                        endVerticeReached = true;
                        break;
                    }

                    if (!visited.Contains(childNode))
                    {
                        nodes.Enqueue(childNode);
                        visited.Add(childNode);
                    }
                }
            }

            if (endVerticeReached)
            {
                var currentNode = end;
                var currentDistance = 0;
                while (currentNode != start)
                {
                    currentDistance++;
                    currentNode = parents[currentNode];
                }

                return currentDistance;
            }
            else
            {
                return -1;
            }
        }
    }
}
