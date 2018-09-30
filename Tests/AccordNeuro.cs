using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Accord.Neuro;
using Accord.Neuro.Learning;
using Accord.Statistics;
using Lab2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccordTest
{
    /// <summary>
    /// Сводное описание для UnitTest1
    /// </summary>
    [TestClass]
    public class AccordNeuro
    {
        
        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AccordTest()
        {
            //
            // TODO: добавьте здесь логику теста
            //
            var Input = new LearningWordAnswer();
            var res = new List<double>();
            var neuro = new ActivationNetwork(new SigmoidFunction(), 64, 1);
            var learn = new PerceptronLearning(neuro);

            do
            {

                foreach (var item in Input.List)
                {
                    learn.Run(item.image, new double[] {(item.Value == 'C') ? 1.0 : -1.0});
                }

                foreach (var item in Input.List)
                {
                    res.Add(neuro.Compute(item.image)[0]);
                }

            } while (res.Equals(new double[] {-1.0, -1.0, 1.0, -1.0, -1.0, -1.0, -1.0}));


            CollectionAssert.AreEqual(res,new double[]{-1.0,-1.0,1.0,-1.0,-1.0,-1.0,-1.0});
          //  Parallel.ForEach(Input.List,Func<double>((x,)=>learn.Run()))
        }
    }
}
