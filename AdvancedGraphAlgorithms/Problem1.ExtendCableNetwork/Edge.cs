namespace Problem1.ExtendCableNetwork
{
    using System;

    public class Edge : IComparable<Edge>
    {
        public int StartNode { get; set; }
        public int EndNode { get; set; }
        public int Weight { get; set; }
        public bool IsConnected { get; set; }

        public Edge(int startNode, int endNode, int weight, bool isConnected)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
            this.IsConnected = isConnected;
        }

        public int CompareTo(Edge other)
        {
            int weightCompared = this.Weight.CompareTo(other.Weight);
            return weightCompared;
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", 
                this.StartNode, this.EndNode, this.Weight);
        }
    }
}
