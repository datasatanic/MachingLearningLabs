using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Tests
{
    [TestClass()]
    public class MyRangeTestsNeiron
    {
        [TestMethod()]
        public void MyRangeTest()
        {
            var t = new MyRange(0, 1);
            CollectionAssert.AreEqual(t.ToDouble(), new double[] { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0 });
        }
    }
}