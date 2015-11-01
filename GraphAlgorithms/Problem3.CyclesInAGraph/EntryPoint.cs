using System.Collections.Generic;
using System.Linq;

namespace Problem3.CyclesInAGraph
{
    using System;

    public class EntryPoint
    {
        private const int NodesCountInVertex = 2;
        private static HashSet<string> visitedNodes;
        private static List<string> cycleNodes;

        //private static string[,] graph =
        //{
        //    {"E", "O"},
        //    {"Q", "P"},
        //    {"P", "B"}
        //};

        //private static string[,] graph =
        //{
        //    {"A", "F"},
        //    {"F", "D"},
        //    {"D", "A"}
        //};

        //private static string[,] graph =
        //{
        //    {"C", "G"}
        //};

        //static string[,] graph =
        //    {
        //        {"K", "X"},
        //        {"X", "Y"},
        //        {"X", "N"},
        //        {"N", "J"},
        //        {"M", "N"},
        //        {"A", "Z"},
        //        {"B", "P"},
        //        {"I", "F"},
        //        {"A", "Y"},
        //        {"Y", "L"},
        //        {"M", "I"},
        //        {"F", "P"},
        //        {"Z", "E"},
        //        {"P", "E"}
        //    };

        private static string[,] graph =
        {
                {"K", "J"},
                {"J", "N"},
                {"N", "L"},
                {"N", "M"},
                {"M", "I"}
        };

        public static void Main()
        {
            Console.WriteLine(CheckForAcyclicGraph());
        }

        public static bool CheckForAcyclicGraph()
        {
            var neighboursCount = new Dictionary<string, HashSet<string>>();
            for (int vertex = 0; vertex < graph.GetLength(0); vertex++)
            {
                for (int node = 0; node < NodesCountInVertex; node++)
                {
                    if (!neighboursCount.ContainsKey(graph[vertex, node]))
                    {
                        neighboursCount[graph[vertex, node]] = new HashSet<string>();
                    }

                    neighboursCount[graph[vertex, node]].Add(graph[vertex, (NodesCountInVertex - 1) - node]);
                }
            }

            var nodes = neighboursCount.Keys.ToList();
            while (true)
            {
                var nodeToRemove = neighboursCount.FirstOrDefault(n => n.Value.Count <= 1).Key;
                if (nodeToRemove == null)
                {
                    break;
                }

                var neibourghsToNodeToRemove = neighboursCount
                    .Where(n => n.Value.Contains(nodeToRemove))
                    .Select(n => n.Key);
                foreach (var neightbour in neibourghsToNodeToRemove)
                {
                    neighboursCount[neightbour].Remove(nodeToRemove);
                }

                neighboursCount.Remove(nodeToRemove);
            }

            if (neighboursCount.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}