namespace Problem2.ModifiedKruskalAlgorithm.Tests
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ModifiedKruskalAlgorithmTests
    {
        [TestMethod]
        public void FisrstSampleInput()
        {
            int nodesCount = 4;

            var edges = new List<Edge>
            {
                new Edge(0, 1, 9),
                new Edge(0, 3, 4),
                new Edge(3, 1, 6),
                new Edge(3, 2, 11),
                new Edge(1, 2, 5)
            };

            var expectedEdges = new Edge[]
            {
                edges[1],
                edges[4],
                edges[2]
            };

            var actualEdges = KruskalAlgorithm.Kruskal(nodesCount, edges);

            CollectionAssert.AreEqual(expectedEdges, actualEdges);
            Assert.AreEqual(15, actualEdges.Sum(e => e.Weight));
        }

        [TestMethod]
        public void SecondSampleInput()
        {
            int nodesCount = 9;

            var edges = new List<Edge>
            {
                new Edge(1, 4, 8),
                new Edge(4, 0, 6),
                new Edge(1, 7, 7),
                new Edge(4, 7, 10),
                new Edge(4, 8, 3),
                new Edge(7, 8, 4),
                new Edge(0, 8, 5),
                new Edge(8, 6, 9),
                new Edge(8, 3, 20),
                new Edge(0, 5, 4),
                new Edge(0, 3, 9),
                new Edge(6, 3, 8),
                new Edge(6, 2, 12),
                new Edge(5, 3, 2),
                new Edge(3, 2, 14)
            };

            var expectedEdges = new Edge[]
            {
                edges[13],
                edges[4],
                edges[5],
                edges[9],
                edges[6],
                edges[2],
                edges[11],
                edges[12]
            };

            var actualEdges = KruskalAlgorithm.Kruskal(nodesCount, edges);

            CollectionAssert.AreEqual(expectedEdges, actualEdges);
            Assert.AreEqual(45, actualEdges.Sum(e => e.Weight));
        }

        [TestMethod]
        public void ThirdSampleInput()
        {
            int nodesCount = 8;

            var edges = new List<Edge>
            {
                new Edge(0, 1, 4),
                new Edge(0, 2, 5),
                new Edge(0, 3, 1),
                new Edge(1, 2, 8),
                new Edge(1, 3, 2),
                new Edge(2, 3, 3),
                new Edge(2, 4, 16),
                new Edge(2, 5, 9),
                new Edge(3, 4, 7),
                new Edge(3, 5, 14),
                new Edge(4, 5, 12),
                new Edge(4, 6, 22),
                new Edge(4, 7, 9),
                new Edge(5, 6, 6),
                new Edge(5, 7, 18),
                new Edge(6, 7, 15)
            };

            var expectedEdges = new Edge[]
            {
                edges[2],
                edges[4],
                edges[5],
                edges[13],
                edges[8],
                edges[7],
                edges[12]
            };

            var actualEdges = KruskalAlgorithm.Kruskal(nodesCount, edges);

            CollectionAssert.AreEqual(expectedEdges, actualEdges);
            Assert.AreEqual(37, actualEdges.Sum(e => e.Weight));
        }
    }
}
