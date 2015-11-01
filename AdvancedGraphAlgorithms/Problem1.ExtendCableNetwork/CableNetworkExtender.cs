namespace Problem1.ExtendCableNetwork
{
    using System.Collections.Generic;
    using System.Linq;

    public class CableNetworkExtender
    {
        private int startBudget;
        private int leftBudget;
        private List<Edge> edges;

        public CableNetworkExtender(
            int startBudget,
            List<Edge> edges)
        {
            this.edges = edges;
            this.startBudget = startBudget;
            this.leftBudget = startBudget;
        }

        public int StartBudget { get; set; }

        public List<Edge> Edges { get; set; } 

        public int CalculateBudgetUsed()
        {
            this.edges.Sort();
            var graph = BuildGraph();
            var spanningTreeNodes = new HashSet<int>();
            var connectedEdges = this.edges
                .Where(e => e.IsConnected);
            foreach (var connectedEdge in connectedEdges)
            {
                spanningTreeNodes.Add(connectedEdge.StartNode);
                spanningTreeNodes.Add(connectedEdge.EndNode);
            }

            foreach (var edge in edges)
            {
                if (!spanningTreeNodes.Contains(edge.StartNode))
                {
                    Prim(graph, spanningTreeNodes, edge.StartNode);
                }

                if (!spanningTreeNodes.Contains(edge.EndNode))
                {
                    Prim(graph, spanningTreeNodes, edge.EndNode);
                }
            }

            var budgetUsed = this.startBudget - this.leftBudget;
            return budgetUsed;
        }

        private void Prim(Dictionary<int, List<Edge>> graph,
            HashSet<int> spanningTreeNodes, int startNode)
        {
            var priorityQueue = new BinaryHeap<Edge>();
            foreach (var childEdge in graph[startNode])
            {
                priorityQueue.Enqueue(childEdge);
            }

            while (priorityQueue.Count > 0)
            {
                var smallestEdge = priorityQueue.ExtractMin();
                if (this.leftBudget >= smallestEdge.Weight)
                {
                    if (spanningTreeNodes.Contains(smallestEdge.StartNode) ^
                    spanningTreeNodes.Contains(smallestEdge.EndNode))
                    {
                        this.leftBudget -= smallestEdge.Weight;
                        var nonTreeNode = spanningTreeNodes.Contains(smallestEdge.StartNode) ?
                           smallestEdge.EndNode : smallestEdge.StartNode;
                        spanningTreeNodes.Add(startNode);
                        if (!spanningTreeNodes.Contains(nonTreeNode))
                        {
                            spanningTreeNodes.Add(nonTreeNode);
                            foreach (var childEdge in graph[nonTreeNode])
                            {
                                priorityQueue.Enqueue(childEdge);
                            }
                        }
                    }
                }
            }
        }

        private Dictionary<int, List<Edge>> BuildGraph()
        {
            var graph = new Dictionary<int, List<Edge>>();
            foreach (var edge in edges)
            {
                if (!graph.ContainsKey(edge.StartNode))
                {
                    graph.Add(edge.StartNode, new List<Edge>());
                }
                graph[edge.StartNode].Add(edge);
                if (!graph.ContainsKey(edge.EndNode))
                {
                    graph.Add(edge.EndNode, new List<Edge>());
                }
                graph[edge.EndNode].Add(edge);
            }

            return graph;
        }
    }
}
