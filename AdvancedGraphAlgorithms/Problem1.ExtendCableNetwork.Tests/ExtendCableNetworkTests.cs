using System.Collections.Generic;

namespace Problem1.ExtendCableNetwork.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExtendCableNetworkTests
    {
        [TestMethod]
        public void FirstSampleInput()
        {
            var extender = new CableNetworkExtender(
                20,
                new List<Edge>()
                {
                    new Edge(1, 4, 8, false),
                    new Edge(4, 0, 6, true),
                    new Edge(1, 7, 7, false),
                    new Edge(4, 7, 10, false),
                    new Edge(4, 8, 3, false),
                    new Edge(7, 8, 4, false),
                    new Edge(0, 8, 5, true),
                    new Edge(8, 6, 9, false),
                    new Edge(8, 3, 20, true),
                    new Edge(0, 5, 4, false),
                    new Edge(0, 3, 9, true),
                    new Edge(6, 3, 8, false),
                    new Edge(6, 2, 12, false),
                    new Edge(5, 3, 2, false),
                    new Edge(3, 2, 14, true)
                });

            var budgetUsed = extender.CalculateBudgetUsed();
            Assert.AreEqual(13, budgetUsed);
        }

        [TestMethod]
        public void SecondSampleInput()
        {
            var extender = new CableNetworkExtender(
                7,
                new List<Edge>()
                {
                    new Edge(0, 1, 9, false),
                    new Edge(0, 3, 4, true),
                    new Edge(3, 1, 6, false),
                    new Edge(3, 2, 11, true),
                    new Edge(1, 2, 5, false)
                });

            var budgetUsed = extender.CalculateBudgetUsed();
            Assert.AreEqual(5, budgetUsed);
        }

        [TestMethod]
        public void ThirdSampleInput()
        {
            var extender = new CableNetworkExtender(
                20,
                new List<Edge>()
                {
                    new Edge(0, 1, 4, false),
                    new Edge(0, 2, 5, false),
                    new Edge(0, 3, 1, true),
                    new Edge(1, 2, 8, false),
                    new Edge(1, 3, 2, false),
                    new Edge(2, 3, 3, false),
                    new Edge(2, 4, 16, false),
                    new Edge(2, 5, 9, false),
                    new Edge(3, 4, 7, false),
                    new Edge(3, 5, 14, false),
                    new Edge(4, 5, 12, false),
                    new Edge(4, 6, 22, false),
                    new Edge(4, 7, 9, false),
                    new Edge(5, 6, 6, false),
                    new Edge(5, 7, 18, false),
                    new Edge(6, 7, 15, false)
                });

            var budgetUsed = extender.CalculateBudgetUsed();
            Assert.AreEqual(12, budgetUsed);
        }
    }
}
