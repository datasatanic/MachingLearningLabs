﻿using Accord.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2;


namespace Lab4Tests
{
    //Todo:Завести эти тесты
    [TestClass()]
    public class RbfNetworkTestsNeiron
    {
        [TestMethod()]
        public void TransposeTest()
        {
            var t = new double[2, 2]{ { 1,2},{ 3,4} };
            t.Transpose();
            CollectionAssert.AreEqual(t,new double[2,2]{{1,3},{2,4}});
        }

        [TestMethod()]
        public void RangeTest()
        {
            var t = new MyRange(0, 1);
            CollectionAssert.AreEqual(t.ToDouble(),new double[]{0,0.1,0.2,0.3,0.4,0.5,0.6,0.7,0.8,0.9,1.0});
        }

    }
}