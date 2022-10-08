using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        
    }
}