using Accord.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2;


namespace Lab4Tests
{
    [TestClass()]
    public class RbfNetworkTestsNeiron
    {
        [TestMethod()]
        public void TransposeTest()
        {
            var t = new double[2, 2]{ { 1,2},{ 3,4} };
            var l=t.Transpose();
            CollectionAssert.AreEqual(l,new double[2,2]{{1,3},{2,4}});
        }
    }
}