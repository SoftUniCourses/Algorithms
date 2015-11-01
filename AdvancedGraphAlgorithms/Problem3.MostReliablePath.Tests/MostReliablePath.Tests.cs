namespace Problem3.MostReliablePath.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MostReliablePathTests
    {
        [TestMethod]
        public void FirstSampleInput()
        {
            var graph = new[,]
            {
                // 0   1   2   3   4   5   6
                { 0,   0,  0, 85, 88,  0,   0 }, // 0
                { 0,   0,  0, 95,  0,  5, 100 }, // 1
                { 0,   0,  0,  0, 14,  0,  95 }, // 2
                { 85, 95,  0,  0,  0, 98,   0 }, // 3
                { 88,  0, 14,  0,  0, 99,   0 }, // 4
                { 0,   5,  0, 98, 99,  0,  90 }, // 5
                { 0, 100, 95,  0,  0, 90,   0 }  // 6
            };

            var actualResutl = MostReliablePathFinder
                .GetMostReliablePath(graph, 0, 6);
            var expectedResult =
                @"Most reliable path reliability: 81.11%
0 -> 4 -> 5 -> 3 -> 1 -> 6";

            Assert.AreEqual(expectedResult, actualResutl);
        }

        [TestMethod]
        public void SecondSampleInput()
        {
            var graph = new[,]
            {
                // 0   1    2   3
                { 0,  94,  97,  0 }, // 0
                { 94,  0,   0, 98 }, // 1
                { 97,  0,   0, 99 }, // 2
                { 0,  98,  99,  0 }  // 3
            };

            var actualResutl = MostReliablePathFinder
                .GetMostReliablePath(graph, 0, 1);
            var expectedResult =
                @"Most reliable path reliability: 94.11%
0 -> 2 -> 3 -> 1";

            Assert.AreEqual(expectedResult, actualResutl);
        }
    }
}
