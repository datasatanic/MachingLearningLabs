using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab1.Tests
{
    [TestClass()]
    public class ReshTests
    {
        [TestMethod()]
        public void SchetTest()
        {
            Assert.IsTrue((Resh.Schet(1) - E) < 0.001);
        }
        [TestMethod()]
        public void SchetTest1()
        {
            Assert.AreEqual(Resh.Schet(0), 1);
        }
    }
}