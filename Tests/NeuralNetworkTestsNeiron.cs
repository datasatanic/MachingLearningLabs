using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2.Program.Tests
{
    [TestClass()]
    public class NeuralNetworkTestsWithNumbers
    {
        private NeuralNetwork t = new NeuralNetwork(15, new LearningNumberList());

        [TestMethod()]
        public void IsThis0Test()
        {

            t.ChangeTarget('0');
            Assert.AreEqual("Да",t.Check( new int[]
            {
                1, 1, 1,
                1, 0, 1,
                1, 0, 1,
                1, 0, 1,
                1, 1, 1
            }));
        }
        [TestMethod()]
        public void IsThis3Test()
        {

            t.ChangeTarget('3');
            Assert.AreEqual("Да", t.Check(new int[]
            {
                1, 1, 1,
                0, 0, 1,
                1, 1, 1,
                0, 0, 1,
                1, 1, 1
            }));
        }
        [TestMethod()]
        public void IsThis7Test()
        {

            t.ChangeTarget('7');
            Assert.AreEqual("Да", t.Check(new int[]
            {
                1, 1, 1,
                0, 0, 1,
                0, 0, 1,
                0, 0, 1,
                0, 0, 1
            }));
        }
        [TestMethod()]
        public void IsThis1Test()
        {
            t.ChangeTarget('6');
            Assert.AreEqual("Да", t.Check(new int[]
            {
                1, 1, 1,
                1, 0, 0,
                1, 1, 1,
                1, 0, 1,
                1, 1, 1
            }));
        }
        [TestMethod()]
        public void IsThisNot4Test()
        {
            t.ChangeTarget('4');
            Assert.AreEqual("Нет", t.Check(new int[]
            {
                1, 1, 1,
                1, 0, 1,
                1, 1, 1,
                1, 0, 1,
                1, 1, 1
            }));
        }
        [TestMethod()]
        public void IsThisRightList5Test()
        {
            string[] s = new string[]{"Нет", "Нет", "Нет", "Нет", "Нет", "Да", "Нет", "Нет", "Нет", "Нет"};
            List<string> rStrings=new List<string>();
            var tl=new LearningNumberList();

            t.ChangeTarget('5');
            foreach (var item in tl.List)
            {
                rStrings.Add(t.Check(item.image));
            };
            CollectionAssert.AreEqual(rStrings.ToArray(),s);
        }
        [TestMethod()]
        public void IsThis4Test()
        {
            t.ChangeTarget('4');
            Assert.AreEqual("Да", t.Check(new int[]
            {
                1, 0, 1,
                1, 0, 1,
                1, 1, 1,
                0, 0, 1,
                0, 0, 1
            }));
        }

    }

    [TestClass()]
    public class NeuralNetworkTestsWithWord
    {
        private NeuralNetwork t = new NeuralNetwork(64, new LearningWordAnswer());

        [TestMethod()]
        public void IsThisATest()
        {
            t.ChangeTarget('A');
            Assert.AreEqual("Да",t.Check(new int[]
            {
                0, 0, 0, 1, 1, 0, 0, 0,
                0, 0, 1, 1, 1, 1, 0, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 1, 1, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
            }));
        }
        [TestMethod()]
        public void IsThisNotATest()
        {
            t.ChangeTarget('B');
            Assert.AreEqual("Нет", t.Check(new int[]
            {
                0, 0, 0, 1, 1, 0, 0, 0,
                0, 0, 1, 1, 1, 1, 0, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 1, 1, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
            }));
        }
        [TestMethod()]
        public void IsThisBrokenATest()
        {
            t.ChangeTarget('A');
            Assert.AreEqual("Да", t.Check(new int[]
            {
                0, 0, 0, 1, 1, 0, 0, 0,
                0, 0, 1, 1, 1, 1, 0, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
            }));
        }
    }
}