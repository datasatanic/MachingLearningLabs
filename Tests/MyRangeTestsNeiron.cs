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
    public class MyMathExtensions
    {
        [TestMethod]
        public void MyMethod()
        {
            var r = new MyRange(0, 1);
            var t = r.ToDouble();
            var s = new double[] { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1 };
            Assert.AreEqual(t.Length,s.Length);
        }
        [TestMethod()]
        public void MyRangeTest()
        {
            var r = new MyRange(0, 1);
            var t = r.ToDouble();
            var s = new double[] {0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1};
            for (int i = 0; i < t.Length; i++)
            {
                if (Math.Abs(t[i] - s[i]) > r.Delta / 10)
                    Assert.Fail();
            }
 
        }
    }
}