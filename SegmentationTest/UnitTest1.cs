using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ECGSegmentation
{
    [TestClass]
    public class UnitTest1
    {
        private DataAccess dataAccess;
        private ECGModel model;

        [TestMethod]
        public void LoadDataset1()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.ReadFile();

            Assert.AreEqual(-0.145, model.basicget[0]);
        }

        [TestMethod]
        public void LoadDataset10()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.SetDataSetNum(10);
            model.ReadFile();

            Assert.AreEqual(-1.0, model.basicget[0]);
        }

        [TestMethod]
        public void ReadPeaks1()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.ReadPeaks();

            Assert.AreEqual("77", model.dbtimeget[0]);
        }

        [TestMethod]
        public void Load500Datas()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.ReadFile();

            Assert.AreEqual(500, model.basicget.Count);
        }

        [TestMethod]
        public void Load100000Datas()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.SetDataNum(100000);
            model.ReadFile();

            Assert.AreEqual(100000, model.basicget.Count);
        }

        [TestMethod]
        public void BaseAccuracy0()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.ReadFile();

            Assert.AreEqual(0, model.accuracy);
        }

        [TestMethod]
        public void ChangeToMaxAccuracy()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.SetAccuracy(15);
            model.ReadFile();

            Assert.AreEqual(15, model.accuracy);
        }
        
        [TestMethod]
        public void LowPass()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.ReadFile();

            model.LowPass();

            Assert.AreEqual(-0.145, model.lowpassget[0]);
            Assert.AreEqual(-1.974999999999997, model.lowpassget[30]);
        }

        [TestMethod]
        public void HighPass()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.ReadFile();

            model.LowPass();
            model.HighPass();

            Assert.AreEqual(-0.145, model.highpassget[0]);
            Assert.AreEqual(-1.974999999999997, model.highpassget[30]);
        }

        [TestMethod]
        public void Derivative()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.ReadFile();

            model.LowPass();
            model.HighPass();
            model.Derivative();

            Assert.AreEqual(-0.145, model.derivativeget[0]);
            Assert.AreEqual(-0.11499999999999921, model.derivativeget[30]);
        }

        [TestMethod]
        public void Squaring()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.ReadFile();

            model.LowPass();
            model.HighPass();
            model.Derivative();
            model.Squaring();

            Assert.AreEqual(Math.Pow(model.derivativeget[0], 2), model.squaringget[0]);
            Assert.AreEqual(Math.Pow(model.derivativeget[30],2), model.squaringget[30]);
        }

        [TestMethod]
        public void Integration()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.ReadFile();

            model.LowPass();
            model.HighPass();
            model.Derivative();
            model.Squaring();
            model.Integration();

            Assert.AreEqual(0.021025, model.integrationget[0]);
            Assert.AreEqual(0.21947739538574154, model.integrationget[30]);
        }

        [TestMethod]
        public void PreprocessingTest()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.ReadFile();

            model.Preprocessing();

            Assert.AreEqual(-1.974999999999997, model.lowpassget[30]);
            Assert.AreEqual(-1.974999999999997, model.highpassget[30]);
            Assert.AreEqual(-0.11499999999999921, model.derivativeget[30]);
            Assert.AreEqual(Math.Pow(model.derivativeget[30], 2), model.squaringget[30]);
            Assert.AreEqual(0.21947739538574154, model.integrationget[30]);
        }

        [TestMethod]
        public void DetectionTest()
        {
            dataAccess = new DataAccess();
            model = new ECGModel(dataAccess);
            model.ReadFile();

            model.Preprocessing();
            model.Detection(false);

            Assert.AreEqual(2, model.timeget.Count);
        }
    }
}
