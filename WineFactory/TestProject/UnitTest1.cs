using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using WineFactory;
namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        private ProductionArea _productionArea;
        private Wine _wine;
        public UnitTest1()
        {
            _productionArea = new ProductionArea();
            _wine = new Wine(new Fermenter(1, 200), Flavors.Grape);
        }
        [TestMethod]
        public void AddWineTest()
        {
            //arrange
            Wine wine = new Wine(new Fermenter(1, 200), Flavors.Grape);

            //act
            _productionArea.AddWine(wine);

            //assert
            Assert.AreEqual(_productionArea.Wines.Count,1);
        }
        [TestMethod]
        public void ReadyTest()
        {
            //arrange
            _wine.State = WineStates.Fermenting;
            System.Timers.ElapsedEventArgs? e = null;

            //act
            _wine.Ready(new object(),e) ;
            
            //assert
            Assert.IsTrue(_wine.State == WineStates.Finished);
        }
        [TestMethod]
        public void FermentationTest()
        {
            //arrange
            _wine.State = WineStates.Iddle;
            _wine.FermentationTime.Interval = 900;

            //act
            _wine.Fermentation();
            Thread.Sleep(1000);

            //assert
            Assert.AreEqual(_wine.State, WineStates.Finished);
        }
    }
}