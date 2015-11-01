namespace Problem4.ShortestPathsBetweenAllPairsOfNodes.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ShortestPathsTests
    {
        [TestMethod]
        public void FirstSampleInput()
        {
            var max = int.MaxValue;
            var distances = new int[,]
            {
               //  0      1    2    3
                {  0,    12,  10, max }, // 0
                { 12,     0,  10,   3 }, // 1
                { 10,    10,   0,   6 }, // 2
                {  max,   3,   6,   0 } // 3
            };

            var actualResult = ShortestPathsFinder.FindShortestPaths(distances);
            var expectedResult = new int[,]
            {
                {  0,    12,  10, 15 },
                { 12,     0,  9,   3 },
                { 10,    9,   0,   6 },
                {  15,   3,   6,   0 }
            };

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
